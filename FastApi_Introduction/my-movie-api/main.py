import json
from fastapi import FastAPI, HTTPException, Body, Request, Path, Query, Depends
from fastapi.responses import HTMLResponse,JSONResponse
from fastapi.security import HTTPBearer 
from typing import List
from movie import Movie
from jwt_manager import create_token, validate_token, JWTBearer
from user import User

app = FastAPI()
app.title = "Mi Aplicación con FastAPI"
app.description = "Una API solo por diversión"
app.version = "0.0.1"

with open('data/movies.json') as data:
  movies = json.load(data)

@app.get('/', tags=['Home'])
def message():
    return HTMLResponse("<h1>Hello World!</h1>")

@app.post('/login', tags=['Auth'])
def login(user: User):
    if user.email == "admin" and user.password == "admin":
        token: str = create_token(user.dict())
        return JSONResponse(status_code=200,content=token)
    else:
        raise HTTPException(status_code=401, detail="Invalid Credentials")

@app.get('/movies', tags=['Movies'], response_model=List[Movie], dependencies=[Depends(JWTBearer())])
def get_movies():
    return JSONResponse(content=movies)

@app.get('/movies/{id}', tags=['Movies'], response_model=List[Movie])
def get_movie(id: int = Path(ge=1, le=2000)):
    for item in movies:
        if item["id"] == id:
            return JSONResponse(content=item)
    raise HTTPException(status_code=404, detail="Movie not found")

@app.get('/movies/', tags = ['Movies'], response_model=List[Movie])
def get_movies_by_category(category: str= Query(default=None,min_length=3,max_length=100), year:int=Query(default=None, ge=1900,le=2100)):
    if category is None and year is None:
        return movies
    else:
        category = category if category is None or len(category) == 0 else category.lower()
        filtered_list_movies = list(filter(lambda x: category == x["category"].lower() or year == x["year"], movies))
        list_movies = list(filtered_list_movies)
        if not list_movies:
            raise HTTPException(status_code=404, detail="Movie not found!")

        return JSONResponse(content=list_movies)

@app.post('/movies/', tags = ['Movies'])
def create_movie(request: Movie):
    movie = request.dict()
    max_id = max([movies_['id'] for movies_ in movies]) 
    movie['id'] = max_id + 1
    movies.append(movie)
    return movies

@app.put('/movies/{id}', tags = ['Movies'])
def update_movie(id: int, request: Movie):
    movie = request.dict()
    for index,item in enumerate(movies):
        if item['id'] == id:
            movie['id'] = id
            movies[index].update(movie)
            return movies
        
@app.delete('/movies/{id}', tags = ['Movies'])
def delete_movie(id: int):
    for item in movies:
        if item['id'] == id:
            movies.remove(item)
            return movies
        