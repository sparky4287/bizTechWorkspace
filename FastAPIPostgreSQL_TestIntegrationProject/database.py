from sqlalchemy import create_engine
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker

# This is the connection string to your local PostgreSQL database.
# Replace `username`, `password`, and `mechs_db` with your actual DB credentials and database name.
SQLALCHEMY_DATABASE_URL = "postgresql://postgres:!xtlmoidq34@localhost:5432/MechwarriorTest"

# Create a SQLAlchemy engine that connects to the PostgreSQL database.
engine = create_engine(SQLALCHEMY_DATABASE_URL)

# This creates a session factory we will use to interact with the database.
SessionLocal = sessionmaker(bind=engine, autocommit=False, autoflush=False)

# This Base class is used by SQLAlchemy to define our table models.
Base = declarative_base()
