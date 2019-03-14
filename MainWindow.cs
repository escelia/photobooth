using System;
using Gtk;

namespace Photobooth
{
	public class MainWindow : Window {

		static CompositeModel _cm = new CompositeModel();

		static Gdk.Pixbuf _backgroundImg = new Gdk.Pixbuf("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/photos/kitty4.jpg");
		static Canvas _canv = new Canvas(_backgroundImg);

		static ListView _list = new ListView("Layer");
		static TransformTool _tt = new TransformTool();

		public MainWindow() : base("Main Window") {

			SetDefaultSize(800,650);
			DeleteEvent += new DeleteEventHandler (delete_cb);
			bool isUniform = false;
         	int margin = 5;

			VBox topPanel = new VBox(isUniform, margin);
			HBox layCan = new HBox(isUniform, margin);
			VBox layout = new VBox(isUniform, margin);
			VBox layBtn = new VBox(isUniform, margin);

			ButtonPressEvent += new ButtonPressEventHandler (ButtonPressHandler);
			MotionNotifyEvent += new MotionNotifyEventHandler (MotionNotifyHandler);
			ButtonReleaseEvent += new ButtonReleaseEventHandler (ButtonReleaseHandler);

			// menu bar

			MenuBar mb = new MenuBar ();
			Menu file_menu = new Menu ();
			MenuItem exit_item = new MenuItem("Exit");
			MenuItem save_item = new MenuItem("Save");
			MenuItem open_item = new MenuItem("Open");

			exit_item.Activated += new EventHandler (on_exit_item_activate);
			open_item.Activated += new EventHandler (OnOpenCallback);
			save_item.Activated += new EventHandler (onSaveCallback);
			file_menu.Append (open_item);
			file_menu.Append (save_item);
			file_menu.Append (exit_item);
			MenuItem file_item = new MenuItem("File");
			file_item.Submenu = file_menu;
			mb.Append (file_item);


			layout.Add(Align(mb, 0, 0.5f, 1, 1));

			// toolbar

			Toolbar toolbar = new Toolbar();

			ToolButton buttonMove = new ToggleToolButton ();
			buttonMove.IconWidget = new Gtk.Image ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/ops/move.png");
			buttonMove.Clicked += new EventHandler(OnMoveClick);

			ToolButton buttonSelect = new ToggleToolButton ();
			buttonSelect.IconWidget = new Gtk.Image ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/ops/scale.png");
			buttonSelect.Clicked += new EventHandler(OnSelectClick);

			ToolButton buttonStar = new ToggleToolButton ();
			var pixbufStar = new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/star.png");
			buttonStar.IconWidget = new Gtk.Image (pixbufStar.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));
			buttonStar.Clicked += new EventHandler(OnStarClick);

			ToolButton buttonAviator = new ToggleToolButton ();
			var pixbufAv = new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/aviator.png");
			buttonAviator.IconWidget = new Gtk.Image (pixbufAv.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));
			buttonAviator.Clicked += new EventHandler(OnAviatorClick);

			ToolButton buttonHeart = new ToggleToolButton ();
			var pixbufH = new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/heart.png");
			buttonHeart.IconWidget = new Gtk.Image (pixbufH.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));
			buttonHeart.Clicked += new EventHandler(OnHeartClick);

			ToolButton buttonNerd = new ToggleToolButton ();
			var pixbufN = new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/nerd.png");
			buttonNerd.IconWidget = new Gtk.Image (pixbufN.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));
			buttonNerd.Clicked += new EventHandler(OnNerdClick);

			ToolButton buttonHorns = new ToggleToolButton ();
			var pixbufHorns = new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/horns.png");
			buttonHorns.IconWidget = new Gtk.Image (pixbufHorns.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));
			buttonHorns.Clicked += new EventHandler(OnHornsClick);

			ToolButton buttonHalo = new ToggleToolButton ();
			var pixbufHalo = new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/halo.png");
			buttonHalo.IconWidget = new Gtk.Image (pixbufHalo.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));
			buttonHalo.Clicked += new EventHandler(OnHaloClick);

			ToolButton buttonTiara = new ToggleToolButton ();
			var pixbufT = new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/tiara.png");
			buttonTiara.IconWidget = new Gtk.Image (pixbufT.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));
			buttonTiara.Clicked += new EventHandler(OnTiaraClick);

			ToolButton buttonMous = new ToggleToolButton ();
			var pixbufM = new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/moustache.png");
			buttonMous.IconWidget = new Gtk.Image (pixbufM.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));
			buttonMous.Clicked += new EventHandler(OnMousClick);

			ToolButton buttonLib = new ToggleToolButton ();
			var pixbufL = new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/librarian.png");
			buttonLib.IconWidget = new Gtk.Image (pixbufL.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));
			buttonLib.Clicked += new EventHandler(OnLibClick);


			SeparatorToolItem sep = new SeparatorToolItem();

			toolbar.Insert (buttonMove, -1);
			toolbar.Insert (buttonSelect, -1);
			toolbar.Insert (sep, -1);
			toolbar.Insert (buttonStar, -1);
			toolbar.Insert (buttonAviator, -1);
			toolbar.Insert (buttonHeart, -1);
			toolbar.Insert (buttonNerd, -1);
			toolbar.Insert (buttonHorns, -1);
			toolbar.Insert (buttonHalo, -1);
			toolbar.Insert (buttonTiara, -1);
			toolbar.Insert (buttonMous, -1);
			toolbar.Insert (buttonLib, -1);
			
			toolbar.ToolbarStyle = ToolbarStyle.BothHoriz;
         	toolbar.ShowArrow = false;
			layout.Add(Align(toolbar, 0, 0.25f, 1, 0));


			layBtn.Add(Align(_list, 1, 0, 0, 1));
			

			Button btn = new Button ("Delete layer");
			btn.Clicked += new EventHandler (btn_click);
			layBtn.Add(Align(btn, 0, 0, 1, 1));
			layCan.Add(Align(layBtn, 1, 0, 0 ,1));

			
			layCan.Add(Align(_canv, 1, 0, 1, 1));
			
			
			topPanel.Add(Align(layout, 1, 0, 1, 1));
			topPanel.Add(Align(layCan, 1, 0, 0, 1));
			Add(topPanel);
			ShowAll ();
		}

		void ButtonPressHandler (object obj, ButtonPressEventArgs args)
		{
			Console.WriteLine("mouse pressed");
			_tt.Activate(args.Event.X, args.Event.Y);
			_tt.DoWork(args.Event.X, args.Event.Y, _list.Selected, _cm);
		}

		void MotionNotifyHandler (object obj, MotionNotifyEventArgs args)
		{
			_tt.DoWork(args.Event.X, args.Event.Y, _list.Selected, _cm);
		}

		void ButtonReleaseHandler (object obj, ButtonReleaseEventArgs args)
		{
			_tt.Deactivate();
		}

		static void btn_click (object obj, EventArgs args)
		{
			//Console.WriteLine ("Button Clicked");
			_cm.DeleteLayer(_list.Selected);
			
		}

		public void on_exit_item_activate(object o, EventArgs args)
		{
			Application.Quit ();
		}

		void OnSelectClick(object sender, EventArgs args)
		{
			_tt.mode = Mode.SCALE;
		}

		void OnMoveClick(object sender, EventArgs args)
		{
			_tt.mode = Mode.TRANSLATE;
		}

		void OnClicked(object sender, EventArgs args)
    	{
        	Application.Quit();
    	}

		void OnStarClick(object sender, EventArgs args)
		{
			_cm.AddLayer(new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/star.png"), "star");
		}

		void OnAviatorClick(object sender, EventArgs args)
		{
			_cm.AddLayer(new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/aviator.png"), "aviator");
		}

		void OnHeartClick(object sender, EventArgs args)
		{
			_cm.AddLayer(new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/heart.png"), "heart");
		}

		void OnNerdClick(object sender, EventArgs args)
		{
			_cm.AddLayer(new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/nerd.png"), "nerd");
		}

		void OnHornsClick(object sender, EventArgs args)
		{
			_cm.AddLayer(new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/horns.png"), "horns");
		}

		void OnHaloClick(object sender, EventArgs args)
		{
			_cm.AddLayer(new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/halo.png"), "halo");
		}

		void OnTiaraClick(object sender, EventArgs args)
		{
			_cm.AddLayer(new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/tiara.png"), "tiara");
		}

		void OnMousClick(object sender, EventArgs args)
		{
			_cm.AddLayer(new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/moustache.png"), "moustache");
		}

		void OnLibClick(object sender, EventArgs args)
		{
			_cm.AddLayer(new Gdk.Pixbuf ("/Users/eliaanagnostou/Documents/cs71/03-photobooth-eanagno1-zbatool1/accessories/librarian.png"), "librarian");
		}

		void onSaveCallback(object sender, EventArgs args)
		{
			Gtk.FileChooserDialog fc =
		new Gtk.FileChooserDialog("Save file",
		                            this,
		                            FileChooserAction.Save,
		                            "Cancel",ResponseType.Cancel,
		                            "Save",ResponseType.Accept);

			fc.Run();
		}

		void OnOpenCallback(object sender, EventArgs args)
      	{

			Gtk.FileChooserDialog fc =
			new Gtk.FileChooserDialog("Choose the file to open",
										this,
										FileChooserAction.Open,
										"Cancel",ResponseType.Cancel,
										"Open",ResponseType.Accept);
/*
			if (fc.Run() == (int)ResponseType.Accept) 
			{
					System.IO.FileStream file = System.IO.File.OpenRead(fc.Filename);
					file.Close();
					if(_cm.LoadBaseImage(fc.Filename) == false){
						string message = "Invalid file name";
						string caption = "Error Detected in Input";

					}
			}
			*/

			if (fc.Run() == (int)ResponseType.Accept) 
			{
					System.IO.FileStream file = System.IO.File.OpenRead(fc.Filename);
					file.Close();
					if(_cm.LoadBaseImage(fc.Filename) == false){
						Gtk.MessageDialog md = new Gtk.MessageDialog (this, 
                            DialogFlags.DestroyWithParent,
	                    MessageType.Error, 
                            ButtonsType.Close, "Error loading file");
	
					int result = md.Run ();
					md.Destroy();

					}
			}


			fc.Destroy();
         
         
      	} 
		
		public static void OnCompositeImageChangeCallBack(Gdk.Pixbuf img)
		{
			_canv.SetImage(img);
		}

		public static void ListUpdate(string layerName)
		{
			_list.AddItem(layerName);
		}

		public static void ListClear()
		{
			_list.Clear();
		}

		Alignment Align(Widget widget, 
         float xalign, float yalign, float xscale, float yscale)
      	{
         Alignment alignment = new Alignment(xalign, yalign, xscale, yscale);
         alignment.Add(widget);
         return alignment;
      	}

		static void delete_cb (object o, DeleteEventArgs args)
		{
			Application.Quit();
		}

   }
}