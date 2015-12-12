using Otter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace YAGJP.Main
{
    class OgmoProjectWithLayerLoading : OgmoProject
    {
        public OgmoProjectWithLayerLoading(string source, string imagePath = "") : base(source, imagePath)
        {
        }

        override public void LoadLevel(string data, Scene scene)
        {
            Entities.Clear();

            CurrentLevel = data;

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(data);

            var xmlLevel = xmlDoc["level"];

            scene.Width = int.Parse(xmlDoc["level"].Attributes["width"].Value);
            scene.Height = int.Parse(xmlDoc["level"].Attributes["height"].Value);

            LoadLayer(scene, xmlLevel, 0, Layers.Values.First());

            if (UseCameraBounds)
            {
                scene.CameraBounds = new Rectangle(0, 0, scene.Width, scene.Height);
                scene.UseCameraBounds = true;
            }
        }

        public void LoadNexLayer(string path, Scene scene, string name)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(File.ReadAllText(path));

            var xmlLevel = xmlDoc["level"];

            scene.Width = int.Parse(xmlDoc["level"].Attributes["width"].Value);
            scene.Height = int.Parse(xmlDoc["level"].Attributes["height"].Value);

            LoadLayer(scene, xmlLevel, Layers.Keys.AsQueryable().ToList().IndexOf(name), Layers[name]);

            if (UseCameraBounds)
            {
                scene.CameraBounds = new Rectangle(0, 0, scene.Width, scene.Height);
                scene.UseCameraBounds = true;
            }
        }

        private int LoadLayer(Scene scene, XmlElement xmlLevel, int index, OgmoLayer layer)
        {
            if (layer.Type == "GridLayerDefinition")
            {
                var Entity = new Entity();

                var grid = new GridCollider(scene.Width, scene.Height, layer.GridWidth, layer.GridHeight);

                grid.LoadString(xmlLevel[layer.Name].InnerText);
                if (ColliderTags.ContainsKey(layer.Name))
                {
                    grid.AddTag(ColliderTags[layer.Name]);
                }

                if (DisplayGrids)
                {
                    var tilemap = new Tilemap(scene.Width, scene.Height, layer.GridWidth, layer.GridHeight);
                    tilemap.LoadString(xmlLevel[layer.Name].InnerText, layer.Color);
                    Entity.AddGraphic(tilemap);
                }

                Entity.AddCollider(grid);

                scene.Add(Entity);
                Entities.Add(layer.Name, Entity);
            }
            if (layer.Type == "TileLayerDefinition")
            {
                var Entity = new Entity();

                var xmlTiles = xmlLevel[layer.Name];

                var tileset = xmlTiles.Attributes["tileset"].Value;

                var tilepath = ImagePath + TileMaps[tileset];

                foreach (var kv in assetMappings)
                {
                    var find = kv.Key;
                    var replace = kv.Value;

                    if (tilepath.EndsWith(find))
                    {
                        tilepath = replace;
                        break;
                    }
                }

                var tilemap = new Tilemap(tilepath, scene.Width, scene.Height, layer.GridWidth, layer.GridHeight);

                var exportMode = xmlTiles.Attributes["exportMode"].Value;
                switch (exportMode)
                {
                    case "CSV":
                        tilemap.LoadCSV(xmlTiles.InnerText);
                        break;
                    case "XMLCoords":
                        foreach (XmlElement t in xmlTiles)
                        {
                            tilemap.SetTile(t);
                        }
                        break;
                }

                tilemap.Update();

                Entity.AddGraphic(tilemap);

                Entity.Layer = BaseTileDepth - index * TileDepthIncrement;

                scene.Add(Entity);
                Entities.Add(layer.Name, Entity);
            }
            if (layer.Type == "EntityLayerDefinition")
            {
                var xmlEntities = xmlLevel[layer.Name];

                if (xmlEntities != null)
                {
                    foreach (XmlElement e in xmlEntities)
                    {
                        CreateEntity(e, scene);
                    }
                }
            }

            return index;
        }

    }
}
