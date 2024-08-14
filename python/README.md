# uwapi for python

Copy the contents of `bot` folder to your new project and do everything there.

## Linux

Installation:

```bash
python3 -m venv venv
source venv/bin/activate
pip3 install -r requirements.txt
```

Running on localhost:

```bash
python3 main.py
```

Running with a ip/port:

```bash
UNNATURAL_CONNECT_ADDR=127.0.0.1 UNNATURAL_CONNECT_PORT=12345 python3 main.py
```

Running with a lobby id:

```bash
UNNATURAL_CONNECT_LOBBY=123456789 python3 main.py
```

## Windows

Installation:

```cmd
python3 -m venv venv
.\venv\Scripts\activate
pip3 install -r requirements.txt
```
