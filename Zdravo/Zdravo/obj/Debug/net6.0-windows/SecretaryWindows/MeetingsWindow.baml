   M S B A M L   `   `   `  ����A  =Zdravo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Zdravo.SecretaryWindowsZdravo.SecretaryWindows  5   	   ,    &Zdravo.SecretaryWindows.MeetingsWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Zdravo.SecretaryWindows     5   	     � Title$  MeetingsWindow��5   	   $	��750��6    $	��430��6-    � WindowStartupLocation$ CenterScreen=�69   .��5	      � .+�5
   
   �� $��Center=�6   $��0,28,0,0q�61   $
��Wrap=�6C   $��Meetings��6W   $	��Top=�6g   $��36(�6   &   System.Windows.Controls.DataGrid  5   
   -   5        $��table��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6       
IsReadOnly$
 True��60      SelectionMode$ Single=�6D      AutoGenerateColumns$ False��5   e   $��30,98,30,396q�6�   ��6   �� *
Meetings+ �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6&   	   Width$
	 0.3* 62   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6?   �� *Id+  5      $ Description��6&   
 6;   �� *Description+  5      $
 Date��6&   $
	 0.7* 64   
 6A   �� *Date+  5      $
 Time��6&   $
	 0.5* 64   
 6A   �� *Time+5      �� 5   
   $��Center=�6   $��	0,367,0,0q�61   $
��Wrap=�6D   $��Participants��6X   $	��Top=�6l   $��20(�6�   �� 5   
   -   5         ��Name$ participantsTextBox��5      $
��Left=�61   $��
81,399,0,0q�6L   $
��Wrap=�6`   $�� ��6t   $	��Top=�6|   �� 5   
   -   5        $
��Back��5      $
��Left=�6    $��
32,658,0,0q�6;   $	��Top=�6O   $��35��6g   $��49��6s   6~   �� 5   
   $��Center=�6   $	��264��61   $��	0,357,0,0q�6>   
���   �$	��Top=�6`   $	��302��6x   �� 5   
   -   5        $	��New��5      $
��Left=�6   $��304,661,0,0q�6:   $	��Top=�6O   $��32��6g   $��62��6s   6~   5      5      