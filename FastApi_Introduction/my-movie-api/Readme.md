Una vez descargado el proyecto se deben realizar los siguientes pasos sobre una terminal dentro del proyecto:

**Para Windows**

1. python -m venv venv
2. 
|OS|Path|
|--|--|
|Windows|.\venv\Scripts\activate|
|Linux|source venv/bin/activate|
|Mac|source venv/bin/activate|

3. pip install -r .\requirements.txt
4. uvicorn main:app --reload --port <port_number> --host 0.0.0.0:<port_number>

_La bandera **host** es opcional_