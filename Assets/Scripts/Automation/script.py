import geopandas as gpd
import json
import sys


shapefile_path = sys.argv[1]
print(shapefile_path)
features = []

gdf = gpd.read_file(shapefile_path)


for index, row in gdf.iterrows():
    geometry = row['geometry']
    # if(index == 10 ):
    #     break
    # print(geometry)
    # print(row)
    object_id = row['OBJECTID']
    if geometry.geom_type == 'Polygon':
        coords = [(point[0], point[1]) for point in geometry.exterior.coords]
        feature = {
            'object_id': f"{object_id}",
            'coordinates': coords
            }
        
        features.append(feature)

output_data = {'features': features}

output_json_path = 'exported_coordinates.json'
with open(output_json_path, 'w') as json_file:
    json.dump(output_data, json_file, indent=2)

print(f"Coordinates exported to {output_json_path}")