using System;
using Gtk;

namespace Photobooth
{
	public class MainWindow {

		public MainWindow() {

			Window win = new Window ("Menu Sample App");
			win.Resize(800,650);
			VBox vbox = new VBox(false, 2);

			// menu bar

			MenuBar mb = new MenuBar ();
			Menu file_menu = new Menu ();
			MenuItem exit_item = new MenuItem("Exit");
			MenuItem save_item = new MenuItem("Save");
			MenuItem open_item = new MenuItem("Open");

			exit_item.Activated += new EventHandler (on_exit_item_activate);
			file_menu.Append (open_item);
			file_menu.Append (save_item);
			file_menu.Append (exit_item);
			MenuItem file_item = new MenuItem("File");
			file_item.Submenu = file_menu;
			mb.Append (file_item);

        	vbox.PackStart(mb, false, false, 0);

			// toolbar

			Toolbar toolbar = new Toolbar();

			ToolButton buttonMove = new ToggleToolButton ();
			buttonMove.IconWidget = new Gtk.Image ("../ops/move.png");

			ToolButton buttonSelect = new ToggleToolButton ();
			buttonSelect.IconWidget = new Gtk.Image ("../ops/scale.png");
			
			ToolButton buttonStar = new ToggleToolButton ();
			var pixbufStar = new Gdk.Pixbuf ("../accessories/star.png");
			buttonStar.IconWidget = new Gtk.Image (pixbufStar.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));

			ToolButton buttonAviator = new ToggleToolButton ();
			var pixbufAv = new Gdk.Pixbuf ("../accessories/aviator.png");
			buttonAviator.IconWidget = new Gtk.Image (pixbufAv.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));

			ToolButton buttonHeart = new ToggleToolButton ();
			var pixbufH = new Gdk.Pixbuf ("../accessories/heart.png");
			buttonHeart.IconWidget = new Gtk.Image (pixbufH.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));

			ToolButton buttonNerd = new ToggleToolButton ();
			var pixbufN = new Gdk.Pixbuf ("../accessories/nerd.png");
			buttonNerd.IconWidget = new Gtk.Image (pixbufN.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));

			ToolButton buttonHorns = new ToggleToolButton ();
			var pixbufHorns = new Gdk.Pixbuf ("../accessories/horns.png");
			buttonHorns.IconWidget = new Gtk.Image (pixbufHorns.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));
			
			ToolButton buttonHalo = new ToggleToolButton ();
			var pixbufHalo = new Gdk.Pixbuf ("../accessories/halo.png");
			buttonHalo.IconWidget = new Gtk.Image (pixbufHalo.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));

			ToolButton buttonTiara = new ToggleToolButton ();
			var pixbufT = new Gdk.Pixbuf ("../accessories/tiara.png");
			buttonTiara.IconWidget = new Gtk.Image (pixbufT.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));

			ToolButton buttonMous = new ToggleToolButton ();
			var pixbufM = new Gdk.Pixbuf ("../accessories/moustache.png");
			buttonMous.IconWidget = new Gtk.Image (pixbufM.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));

			ToolButton buttonLib = new ToggleToolButton ();
			var pixbufL = new Gdk.Pixbuf ("../accessories/librarian.png");
			buttonLib.IconWidget = new Gtk.Image (pixbufL.ScaleSimple(30, 30, Gdk.InterpType.Bilinear));

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
			
			vbox.PackStart(toolbar, false, false, 0);

			ListView list = new ListView("Layer");
			vbox.PackStart(list, false, false, 0);

			Gdk.Pixbuf backgroundImg = new Gdk.Pixbuf("../photos/kitty4.jpg");
			Canvas canv = new Canvas(backgroundImg);
			vbox.PackStart(canv, false, false, 0);
			
			
        	win.Add(vbox);
			win.ShowAll ();
		}

		public void on_exit_item_activate(object o, EventArgs args)
		{
			Application.Quit ();
		}

		void OnClicked(object sender, EventArgs args)
    	{
        Application.Quit();
    	}

   }
}