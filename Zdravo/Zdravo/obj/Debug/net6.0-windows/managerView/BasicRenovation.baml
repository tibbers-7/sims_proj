   M S B A M L   `   `   `  ����A  =Zdravo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Zdravo.managerViewZdravo.managerView  5   	   (    "Zdravo.managerView.BasicRenovation   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Zdravo.managerView     5   	     � Title$  BasicRenovation��5   	   $	��450��6!   $	��800��6.   .��5	      � .+�5
   
   (  "System.Windows.Controls.DatePicker  -   5        $��RenDate��5
      $
��Left=�6B   $��530,157,0,0q�6]   $	��Top=�6r      SelectedDate 6$   �� *Date+6r   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridRooms��5   #      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6      
IsReadOnly$
 True��6X      SelectionMode$ Single=�5         AutoGenerateColumns$ False��6*   $
��Left=�6F   $��45,124,0,124q�6a   $	��355��6w   ��5   :   �� *rooms+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *id+  5      $ sprat��6%   	 64   �� *floor+  5      $	 tip��6%   	 62   �� *type+5      �� 5   
   $��Kratak opis:��6   $
��Left=�6'   $��434,335,0,0q�6B   $	��Top=�6W   �� 5   
   $
��Left=�6   $��530,339,0,0q�6-   
 �� TextWrapping$

 Wrap=�6B   $	��Top=�6�   $	��120��6�   ��6V   ��  �� Path$ Description� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   -   5        $��Potvrdi��5      $
��Left=�6#   $��
45,385,0,0q�6>   $	��Top=�6R   $��24��6j   $��71��6v   6�   �� 5   
   $&�� Zakazivanje osnovnog renoviranja��6   $
��Left=�6;   $��	45,42,0,0q�6V   $	��Top=�6i   $��30��6�   $	��203��6�   �� 5   
   $	��Id:��6   $
��Left=�6   $��451,292,0,0q�69   $	��Top=�6N   �� 5   
   $
��Left=�6   $��560,305,0,0q�6-   $

 Wrap=�6B   $	��Top=�6�   $	��120��6�   ��6V   �� $ Id�$ PropertyChanged=�6�   5      5      