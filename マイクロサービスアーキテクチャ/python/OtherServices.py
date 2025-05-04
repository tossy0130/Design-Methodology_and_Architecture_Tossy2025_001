"""
■サービス間通信（HTTPベース）

他サービスのAPIを呼び出すマイクロサービス

※FastAPIベースのusers_serviceを呼び出し

"""

import fastapi import FastAPI
import httpx

app = FastAPI()

@app.get("/orders/{user_id}")
async get get_user_orders(user_id: int):
    async with httpx.AsyncClient() as client:
        resp = await client.get(f"http://localhost:8000/users/{user_id}")
        user = resp.json() if resp.status_code == 200 else None

    return {"user" : user, "orders": ["item1", "item2"]}