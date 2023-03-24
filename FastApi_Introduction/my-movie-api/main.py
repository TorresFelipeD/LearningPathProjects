import json
from fastapi import FastAPI, HTTPException, Body, Request
from fastapi.responses import HTMLResponse,JSONResponse
from pydantic import BaseModel

app = FastAPI()
app.title = "Mi Aplicación con FastAPI"
app.description = "Una API solo por diversión"
app.version = "0.0.1"

class BodyRequest(BaseModel):
    id: int
    title: str
    overview: str
    year: int
    rating: float
    category: str

with open('data/movies.json') as data:
  movies = json.load(data)

@app.get('/', tags=['Home'])
def message():
    return HTMLResponse("<h1>Hello World!</h1>")

@app.get('/movies', tags=['Movies'])
def get_movies():
    return movies

@app.get('/movies/{id}', tags=['Movies'])
def get_movie(id: int):
    for item in movies:
        if item["id"] == id:
            return item
    raise HTTPException(status_code=404, detail="Movie not found")

@app.get('/movies/', tags = ['Movies'])
def get_movies_by_category(category: str=None, year:int=None):
    category = category if category is None or len(category) == 0 else category.lower()
    filtered_list_movies = list(filter(lambda x: category == x["category"].lower() or year == x["year"], movies))
    list_movies = list(filtered_list_movies)
    if not list_movies:
        raise HTTPException(status_code=404, detail="Movie not found!")

    return JSONResponse(content=list_movies)

@app.post('/movies/', tags = ['Movies'])
def create_movie(request: BodyRequest):
    movie = request.dict()
    max_id = max([movies_['id'] for movies_ in movies]) 
    movie['id'] = max_id + 1
    movies.append(movie)
    return movies

@app.put('/movies/{id}', tags = ['Movies'])
def update_movie(id: int, request: BodyRequest):
    movie = request.dict()
    for item in movies:
        if item['id'] == id:
            item['title'] = movie['title'] 
            item['overview'] = movie['overview']
            item['year'] = movie['year'] 
            item['rating'] = movie['rating']
            item['category'] = movie['category']
            return movies
        
@app.delete('/movies/{id}', tags = ['Movies'])
def delete_movie(id: int):
    for item in movies:
        if item['id'] == id:
            movies.remove(item)
            return movies
        