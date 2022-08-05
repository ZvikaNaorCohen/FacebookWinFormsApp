﻿using System;
using System.Drawing;
using System.Windows.Forms;
using FacebookEngine;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    internal class FormAlbums : Form
    {
        private const int k_PictureSize = 100;
        private UserData m_UserData;
        private TableLayoutPanel albumTableLayoutPanel;

        internal FormAlbums(UserData i_UserData)
        {
            m_UserData = i_UserData;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            albumTableLayoutPanel = new TableLayoutPanel();
            albumTableLayoutPanel.Top = 0;
            Controls.Add(albumTableLayoutPanel);
            showAllAlbums();
        }

        private void showAllAlbums()
        {
            albumTableLayoutPanel.ColumnCount =
                albumTableLayoutPanel.RowCount = m_UserData.GetSortedAlbumsList(eSortBy.Name).Count;
            albumTableLayoutPanel.Size = new Size(
                albumTableLayoutPanel.RowCount * k_PictureSize,
                albumTableLayoutPanel.ColumnCount * k_PictureSize);
            foreach (Album album in m_UserData.GetSortedAlbumsList(eSortBy.Name))
            {
                ButtonAlbum albumButton = new ButtonAlbum(album, k_PictureSize);

                albumButton.Dock = DockStyle.Fill;
                albumButton.Text = album.Name;
                albumButton.Click += buttonAlbum_Clicked;
                albumTableLayoutPanel.Controls.Add(albumButton);
            }
        }

        private void showAlbum(Album i_Album)
        {
            albumTableLayoutPanel.Controls.Clear();
            foreach(Photo photo in i_Album.Photos)
            {
                PictureBox pictureBox = new PictureBox();

                pictureBox.Margin = new Padding(0);
                pictureBox.Size = new Size(k_PictureSize, k_PictureSize);
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Image = photo.ImageNormal;
                albumTableLayoutPanel.Controls.Add(pictureBox);
            }
        }

        private void buttonAlbum_Clicked(object sender, EventArgs e)
        {
            if(sender is ButtonAlbum selectedAlbum)
            {
                showAlbum(selectedAlbum.Album);
            }
        }
    }
}
