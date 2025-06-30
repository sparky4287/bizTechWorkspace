from sqlalchemy import Column, String, Float, Integer
from sqlalchemy.dialects.postgresql import UUID
import uuid

from database import Base

# SQLAlchemy model representing the "mechs" table in the database
class Mech(Base):
    __tablename__ = "mechs"  # Name of the table in the database

    # Columns and their types
    id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4, index=True)
    name = Column(String, index=True)       # Mech's name
    model = Column(String)                  # Model name or type
    weight = Column(Float)                  # Weight in tons
    firepower = Column(Integer)             # Firepower rating (e.g. 0–100)
