   M S B A M L   `   `   `  ����A  =Zdravo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ZdravoZdravo  5   	   ,    &Zdravo.managerView.EquipmentRelocation   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Zdravo     5   	     � Title$  EquipmentRelocation��5   	   $	��450��6%   $	��800��62   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridEquipment��5
   #      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6      
IsReadOnly$
 True��6`      SelectionMode$ Single=�5         AutoGenerateColumns$ False��6*   $
��Left=�6F   $��45,124,0,124q�6a   $	��355��6w   ��5
   >   �� *	Equipment+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *id+  5      $ naziv��6%    64   �� *name+  5      $ kolicina��6%    67   �� *amount+  5      $ 
prostorija��6%    69   �� *roomId+5        5   
   -   5        $ dataGridRooms��5   #   $ * 6   $
 True��6X   $ Single=�5      $ False��6*   $
��Left=�6F   $��450,124,0,124q�6a   $��79��6x   ��5   :   �� *Rooms+ 5        5      $ 
Prostorije��6%    69   �� *id+5      (  "System.Windows.Controls.DatePicker  5   
   -   5        $��RelDate��5      $
��Left=�6B   $��606,124,0,0q�6]   $	��Top=�6r   	   SelectedDate	 6$   �� *Date+6r   �� 5   
   -   5        $��Potvrdi��5      $��Center=�6#   $��	0,355,0,0q�6@   $	��Top=�6S   $��32��6k   $	��117��6w   6�   �� 5   
   $��
Količina:��6   $
��Left=�6$   $��606,284,0,0q�6?   $	��Top=�6T   �� 5   
   $
��Left=�6   $��657,288,0,0q�6-   
 �� TextWrapping$

 Wrap=�6B   $	��Top=�6�   $	��120��6�   ��6V   ��  �� Path$ Amount� �� UpdateSourceTrigger$ PropertyChanged=�6�   5      5      