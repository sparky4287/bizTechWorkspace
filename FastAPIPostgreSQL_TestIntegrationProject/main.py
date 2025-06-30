from fastapi import FastAPI, HTTPException, Depends
from sqlalchemy.orm import Session
from uuid import UUID

# Importing your models, schemas, and database connection
import models, schemas
from database import SessionLocal, engine, Base

# Create database tables based on the SQLAlchemy models if they don't exist
Base.metadata.create_all(bind=engine)

# Create the FastAPI app instance
app = FastAPI()

# Dependency that provides a new DB session for each request
def get_db():
    db = SessionLocal()
    try:
        yield db  # gives the database session to the request handler
    finally:
        db.close()  # ensures the session is closed after the request


# POST /mechs/ — Create a new mech
@app.post("/mechs/", response_model=schemas.Mech, status_code=201)
def create_mech(mech: schemas.MechCreate, db: Session = Depends(get_db)):
    # Turn Pydantic data into a SQLAlchemy Mech object
    db_mech = models.Mech(**mech.model_dump())
    db.add(db_mech)        # Add the mech to the session
    db.commit()            # Commit the transaction
    db.refresh(db_mech)    # Refresh to get updated data like `id`
    return db_mech


# GET /mechs/ — Get a list of all mechs
@app.get("/mechs/", response_model=list[schemas.Mech])
def read_mechs(db: Session = Depends(get_db)):
    return db.query(models.Mech).all()  # Return all mechs from DB


# GET /mechs/{mech_id} — Get a specific mech by UUID
@app.get("/mechs/{mech_id}", response_model=schemas.Mech)
def read_mech(mech_id: UUID, db: Session = Depends(get_db)):
    mech = db.query(models.Mech).filter(models.Mech.id == mech_id).first()
    if not mech:
        raise HTTPException(status_code=404, detail="Mech not found")
    return mech


# PUT /mechs/{mech_id} — Update an existing mech
@app.put("/mechs/{mech_id}", response_model=schemas.Mech)
def update_mech(mech_id: UUID, updated: schemas.MechCreate, db: Session = Depends(get_db)):
    mech = db.query(models.Mech).filter(models.Mech.id == mech_id).first()
    if not mech:
        raise HTTPException(status_code=404, detail="Mech not found")

    # Update each field from the incoming request
    for key, value in updated.model_dump().items():
        setattr(mech, key, value)

    db.commit()         # Save changes
    db.refresh(mech)    # Refresh to get updated fields
    return mech


# DELETE /mechs/{mech_id} — Delete a mech
@app.delete("/mechs/{mech_id}", status_code=204)
def delete_mech(mech_id: UUID, db: Session = Depends(get_db)):
    mech = db.query(models.Mech).filter(models.Mech.id == mech_id).first()
    if not mech:
        raise HTTPException(status_code=404, detail="Mech not found")
    db.delete(mech)
    db.commit()
