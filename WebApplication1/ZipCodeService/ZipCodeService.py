import traceback
import requests
import pyodbc
from pprint import pprint
def get_zips():
    try:
        response = requests.get("https://api.dataforsyningen.dk/postnumre")

        cities_info = [{"zip":x['nr'], "city":x['navn']} for x in response.json()]

        pprint(cities_info)
        
    except Exception:
        traceback.print_exc()

get_zips()