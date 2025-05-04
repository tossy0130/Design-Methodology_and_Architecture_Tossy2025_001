from fastapi import FastAPI, HTTPException
from pydantic import BaseModel
from typing  import Dict

# CRUDマイクロサービス

app = FastAPI()

class User(BasesModel):
    id: int
    name: str
    email: str

# 疑似 DB
user_db: Dict[int, User] = {}

@app.post('/users')
def create_user(user: User):
    if user.id in user_db:
        raise HTTPException(status_code=400, detail="User aleready exists")
    user_db[user.id] = user 
    return user

@app.get('/users/{user_id}')
def get_user(user_id: int):
    if user_id not in user_db:
        raise HTTPException(status_code=404, detail="User not found")
    return user_db[user_id]