   M S B A M L   `   `   `  ����A  =Zdravo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Zdravo.managerViewZdravo.managerView  5   	   (    "Zdravo.managerView.EquipmentReview   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Zdravo.managerView     5   	     � Title$  EquipmentReview��5   	   $	��450��6!   $	��800��6.   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridEquipment��5
   #      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6      
IsReadOnly$
 True��6`      SelectionMode$ Single=�5         AutoGenerateColumns$ False��6*   $
��Left=�6F   $��206,124,0,124q�6a   $	��355��6x   ��5
   >   �� *	Equipment+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *id+  5      $ naziv��6%    64   �� *name+  5      $ kolicina��6%    67   �� *amount+  5      $ 
prostorija��6%    69   �� *roomId+5      �� 5   
   $��Premestanje��6   $
��Left=�6'   $��384,373,0,0q�6B   $	��Top=�6W   �� 5   
   -   5        $��searchTb��5      $
��Left=�6"   $��
206,83,0,0q�6=   	 �� TextWrapping$
	 Wrap=�6Q   $	��Top=�6e   $	��120��6}   �� 5   
   -   5        $��Search��5      $��Center=�6"   $��0,83,0,0q�6?   $	��Top=�6Q   $��18��6i   $��48��6u   6�   5      5      