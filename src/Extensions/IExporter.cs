/*
 * IExporter.cs
 *
 * Author(s)
 * 	Stephane Delcroix  <stephane@delcroix.org>
 *
 * This is free software. See COPYING for details.
 *
 */

using Mono.Addins;
using System;

namespace FSpot.Extensions
{
	public interface IExporter
	{
		void Run (IBrowsableCollection selection);
	}

	public delegate FSpot.PhotoArray SelectedImages ();

	[ExtensionNode ("ExportMenuItem")]
	public class ExportMenuItemNode : MenuItemNode
	{

		[NodeAttribute ("command_type", true)]
		string command_type;

		public static SelectedImages SelectedImages;

		protected override void OnActivated (object o, EventArgs e)
		{
			IExporter exporter = (IExporter) Addin.CreateInstance (command_type);
			exporter.Run (SelectedImages ());
		}
	}


}