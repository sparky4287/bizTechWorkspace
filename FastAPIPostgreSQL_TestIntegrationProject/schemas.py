from pydantic import BaseModel
from uuid import UUID

# Base schema shared by both incoming requests and outgoing responses
class MechBase(BaseModel):
    name: str
    model: str
    weight: float
    firepower: int

# Schema used specifically when creating a new mech (no `id` field required)
class MechCreate(MechBase):
    pass

# Schema used when returning a mech from the API (includes `id`)
class Mech(MechBase):
    id: UUID  # This will come from the database when a Mech is created or retrieved

    class Config:
        orm_mode = True  # Enables compatibility with SQLAlchemy models
