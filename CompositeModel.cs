using Gdk;
using System;
using System.Collections.Generic;
namespace Photobooth
{
    // Your CompositeImage class here

    class CompositeModel
    {
        List<Layer> _layers = new List<Layer>();
        Gdk.Pixbuf _baseImage = new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/photos/kitty4.jpg");
        Gdk.Pixbuf _compositeImage = new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/photos/kitty4.jpg");
        List<KeyCallbackFn> _compChange = new List<KeyCallbackFn>();
        List<KeyCallbackFn> _layerChange = new List<KeyCallbackFn>();
        public delegate void KeyCallbackFn(char k);

        public CompositeModel()
        {

        }

        public Gdk.Pixbuf compositeImage
        {
            get { return _compositeImage; }
        }

        public int numLayers
        {
            get { return _layers.Count; }
        }

        // public methods

        public void RemoveLayerChangedCallback(KeyCallbackFn callback)
        {
            _layerChange.Remove(callback);
        }

        public void AddLayerChangedCallback(KeyCallbackFn callback)
        {
            _layerChange.Add(callback);
        }

        public void RemoveCompositeChangedCallback(KeyCallbackFn callback)
        {
            _compChange.Remove(callback);
        }

        public void AddCompositeChangedCallback(KeyCallbackFn callback)
        {
            _compChange.Add(callback);
        }

        public void DeleteLayer(int id)
        {
            _layers.RemoveAt(id);
            MainWindow.ListClear();
            _compositeImage = new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/photos/kitty4.jpg");
            foreach (Layer layer in _layers)
            {
                MainWindow.ListUpdate(layer.Name);
                layer.Apply(_compositeImage);
            }
            MainWindow.OnCompositeImageChangeCallBack(_compositeImage);

            // invokes composite and layer callbacks

                char key = Console.ReadKey(true).KeyChar;
                foreach (KeyCallbackFn cb in _compChange)
                {
                    cb(key);
                }

                foreach (KeyCallbackFn cb in _layerChange)
                {
                    cb(key);
                }
        } 

        public void ScaleLayer(int id, double size)
        {
            if(id >= 0)
            {
                Gdk.Pixbuf scaledBuff = _layers[id].OriginalImage;
                Gdk.Pixbuf copy = _compositeImage.Copy();
                scaledBuff = _layers[id].OriginalImage.ScaleSimple(((int) size + 1) * 30, ((int) size + 1) * 30, Gdk.InterpType.Bilinear);
                Layer scaledLayer = new Layer(scaledBuff, _layers[id].Name);
                _layers[id] = scaledLayer;
                _layers[id].Apply(_compositeImage);
                MainWindow.OnCompositeImageChangeCallBack(_compositeImage);
                _compositeImage = copy;
            }

            //invokes composite image callbacks
            
            if (Console.KeyAvailable)
            {
                char key = Console.ReadKey(true).KeyChar;
                foreach (KeyCallbackFn cb in _compChange)
                {
                    cb(key);
                }
            }
            
        }


        public void MoveLayer(int id, double x, double y)
        {
            Gdk.Pixbuf copy = _compositeImage.Copy();

            if(id <= 0)
            {
                if(_layers[id].Hits(x, y))
                {
                    //Gdk.Pixbuf copy = _compositeImage.Copy();
                    _layers[id].X = x;
                    _layers[id].Y = y;
                    _layers[id].Apply(_compositeImage);
                    MainWindow.OnCompositeImageChangeCallBack(_compositeImage);
                    _compositeImage = copy;

                }
            }
        }

        public string GetLayerName(int id)
        {
            return _layers[id].Name;
        }

        public void AddLayer(Gdk.Pixbuf pixels, string name)
        {
            Layer newLayer = new Layer (pixels, name);
            _layers.Add(newLayer);
            newLayer.Apply(_compositeImage);
            MainWindow.OnCompositeImageChangeCallBack(_compositeImage);
            MainWindow.ListUpdate(name);
/* 
            if (Console.KeyAvailable)
            {
                char key = Console.ReadKey(true).KeyChar;
                foreach (KeyCallbackFn cb in _layerChange)
                {
                    cb(buff);
                }
            }*/
        }

        public bool LoadBaseImage (string filename){
            try{

                _baseImage = new Pixbuf (filename);
                _compositeImage = new Pixbuf (filename);
                MainWindow.OnCompositeImageChangeCallBack(_baseImage);
                return true;
            }
            catch{
                return false;
            }
        }
        
    }
}