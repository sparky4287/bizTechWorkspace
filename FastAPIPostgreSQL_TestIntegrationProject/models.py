from sqlalchemy import Column, DateTime, String, Float, Integer
from sqlalchemy.dialects.postgresql import UUID
import uuid

from database import Base

# SQLAlchemy model representing the "mechs" table in the database
class Mech(Base):
    __tablename__ = "mechs"  # Name of the table in the database

    # Columns and their types
    id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4, index=True)
    name = Column(String, index=True)       # Mech's name
    description = Column(String)            # Description of the Mech
    mechwarrior_id = Column(Integer)        # Pilot id

# SQLAlchemy model representing the "mechwarriors" table in the database
class Mechwarrior(Base):
    __tablename__ = "mechwarriors"  # Name of the table in the database

    # Columns and their types
    id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4, index=True)
    hire_date = Column(DateTime)            # Mechwarrior's hire date
    experience_id = Column(Integer)         # Mechwarrior's experience level
    rank_id = Column(Integer)               # Mechwarrior's rank
    score = Column(Integer)                 # Kill score
    background = Column(String)             # Optional background information

# SQLAlchemy model representing the "experiencelevels" table in the database
class ExperienceLevel(Base):
    __tablename__ = "experiencelevels"  # Name of the table in the database

    # Columns and their types
    id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4, index=True)
    name = Column(String, index=True)       # Experience Level's name

# SQLAlchemy model representing the "ranks" table in the database
class Rank(Base):
    __tablename__ = "ranks"  # Name of the table in the database

    # Columns and their types
    id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4, index=True)
    name = Column(String, index=True)       # Rank's name
