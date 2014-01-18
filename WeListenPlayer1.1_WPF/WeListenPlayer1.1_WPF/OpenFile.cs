using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeListenPlayer1._1_WPF
{
    class OpenFile
    {
        //Playlist Variables
        //These variables are string array lists to store song locations.
        ArrayList filesReturn = new ArrayList();
        ArrayList pathsReturn = new ArrayList();

        ArrayList AddToPlayLIst()
        {

            ArrayList returnArrayList = new ArrayList();
            //Open file dialog to select tracks and add them to the
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "MP3 File (*.mp3)|*.mp3;";
            open.DefaultExt = ".mp3";
            open.Multiselect = true;

            //Show open
            Nullable<bool> result = open.ShowDialog();

            //Process open file dialog box result
            if (result == true)
            {
                //add files to arrays
                filesReturn.AddRange(open.SafeFileNames); //Saves only the names
                pathsReturn.AddRange(open.FileNames); //Saves the full paths
                returnArrayList.Add(filesReturn);
                returnArrayList.Add(pathsReturn);
            }
            
            return returnArrayList;
        }

    }
}
