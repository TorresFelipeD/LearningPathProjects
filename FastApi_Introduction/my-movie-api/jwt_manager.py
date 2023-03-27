from jwt import encode, decode
from fastapi import Request, HTTPException
from fastapi.security import HTTPBearer

def create_token(data: dict):
    token: str = encode(payload=data, key="my_secret_key", algorithm="HS256")
    return token

def validate_token(token: str) -> dict:
    data: dict=decode(token, key="my_secret_key", algorithms=['HS256'])
    return data

class JWTBearer(HTTPBearer):
    async def __call__(self, request: Request):
        auth = await super().__call__(request)
        data = validate_token(auth.credentials)
        if data['email'] != "admin":
            raise HTTPException(status_code=401, detail="Invalid Credentials")