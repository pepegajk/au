   M S B A M L   `   `   `  ����  audioplayer    audioplayer.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Audio Player��5   	   $	��450��6   $	��800��6+   .��5      � .+�5   
   �� -   5        $��PlaylistListBox��5      $
��Left=�5      $	��300��6-   $��	10,10,0,0q�6:   $	��Top=�6M   $	��774��6e   �� 5	   
   -   5        $��PositionSlider��5	      $
��Left=�5
      $��
10,316,0,0q�6,   $	��Top=�6@   $	��774��6X   �� 5   
   -   5        $��SelectFolder��5      $��Select Folder��6@   $
��Left=�5      $��
10,371,0,0q�6,   $	��Top=�6@   $	��774��6X   r� 5   
   -   5        $��AudioPlayerMediaElement��5       r� UnloadedBehavior$
 Stop=�5   G    r� LoadedBehavior$ Manual=�5      $
��Left=�6/   $��0��6J   $��
10,346,0,0q�6U   $	��Top=�5      $	��774��6/   �� 5   
   -   5        $��PlayPauseButton��5      $��
Play/Pause��6?   $
��Left=�5      $��120,346,0,0q�6,   $	��Top=�6A   �� 5   
   -   5        $��
SkipButton��5      $
��Skip��6<   $
��Left=�5      $��220,346,0,0q�6,   $	��Top=�6A   �� 5   
   -   5        $��RepeatButton��5      $��Repeat��6@   $
��Left=�5      $��320,346,0,0q�6,   $	��Top=�6A   �� 5   
   -   5        $��VolumeSlider��5       � Maximum$ 1Q�6N    � Value$	 0.5Q�6Z    �� TickFrequency$	 0.1Q�5      $
��Left=�6%   $��
10,346,0,0q�6@   $	��Top=�6T   $	��100��6l   5      5       