   M S B A M L   `   `   `  ����A  =Zdravo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Zdravo.managerViewZdravo.managerView  5   	   *    $Zdravo.managerView.ComplexRenovation   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Zdravo.managerView     5   	     � Title$  ComplexRenovation��5   	   $	��450��6#   $	��800��60   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridRooms��5
   #      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6      
IsReadOnly$
 True��6X      SelectionMode$ Extended=�5         AutoGenerateColumns$ False��6-   $
��Left=�6I   $��201,53,0,195q�6d   $	��355��6z   ��5
   :   �� *rooms+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *id+  5      $ sprat��6%    64   �� *floor+  5      $	 tip��6%    62   �� *type+5      �� 5   
   $��Spajanje��6   $
��Left=�6$   $��228,310,0,0q�6?   $	��Top=�6T   $��25��6l   $��63��6x   �� 5   
   $��Razdvajanje��6   $
��Left=�6'   $��450,310,0,0q�6B   $	��Top=�6W   $��25��6o   $��78��6{   5      5      