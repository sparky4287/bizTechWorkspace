from pydantic import BaseModel
from uuid import UUID
from datetime import datetime

# MECHS
# Base schema shared by both incoming requests and outgoing responses
class MechBase(BaseModel):
    name: str
    description: str
    mechwarrior_id: int

# Schema used specifically when creating a new mech (no `id` field required)
class MechCreate(MechBase):
    pass

# Schema used when returning a mech from the API (includes `id`)
class Mech(MechBase):
    id: UUID  # This will come from the database when a Mech is created or retrieved

    class Config:
        orm_mode = True  # Enables compatibility with SQLAlchemy models

# MECHWARRIORS
# Base schema shared by both incoming requests and outgoing responses
class MechwarriorBase(BaseModel):
    hire_date: datetime
    experience_id: int
    rank_id: int
    score: int
    background: str

# Schema used specifically when creating a new mechwarrior (no `id` field required)
class MechwarriorCreate(MechwarriorBase):
    pass

# Schema used when returning a mechwarrior from the API (includes `id`)
class Mechwarrior(MechwarriorBase):
    id: UUID  # This will come from the database when a Mechwarrior is created or retrieved

    class Config:
        orm_mode = True  # Enables compatibility with SQLAlchemy models

# EXPERIENCELEVELS
# Base schema shared by both incoming requests and outgoing responses
class ExperienceLevelBase(BaseModel):
    name: str

# Schema used specifically when creating a new experience level (no `id` field required)
class ExperienceLevelCreate(ExperienceLevelBase):
    pass

# Schema used when returning a experience level from the API (includes `id`)
class ExperienceLevel(ExperienceLevelBase):
    id: UUID  # This will come from the database when a ExperienceLevel is created or retrieved

    class Config:
        orm_mode = True  # Enables compatibility with SQLAlchemy models

# RANKS
# Base schema shared by both incoming requests and outgoing responses
class RankBase(BaseModel):
    name: str

# Schema used specifically when creating a new rank (no `id` field required)
class RankCreate(RankBase):
    pass

# Schema used when returning a rank from the API (includes `id`)
class Rank(RankBase):
    id: UUID  # This will come from the database when a Rank is created or retrieved

    class Config:
        orm_mode = True  # Enables compatibility with SQLAlchemy models

