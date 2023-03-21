from fastapi import FastAPI

app = FastAPI()
app.title = "Mi Aplicación con FastAPI"
app.description = "Una API solo por diversión"
app.version = "0.0.1"

@app.get('/', tags=['Home'])
def message():
    return "Hello World!"