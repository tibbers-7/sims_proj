   M S B A M L   `   `   `  ����A  =Zdravo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Zdravo.DoctorViewZdravo.DoctorView  5   	   3clr-namespace:Zdravo.ViewModelZdravo.ViewModel  5   
   %    Zdravo.DoctorView.ChoosePatient   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Zdravo.DoctorView     5   	   4	viewmodelclr-namespace:Zdravo.ViewModel     5   
     � Title$  ChoosePatient��5	   	   $	��391��6   $	��306��6,   $��	Yu Gothic)�68   ���	#FFF0F7F4.��5      � $��	0,10,0,-6q�6   .+�5   
   �� ���#70ABAF���	#FF70ABAF$��1q�6>    �� CornerRadius$ 8��6R   $��159,286,86,18q�6c   ._�5      � .+�5      �� -   5        $�� ��5      $��	7,0,10,10q�6$   ��6R   Z� ��5      �� 5       �� ImageSource$  /Resources/cancelWhite.png��6%   5      �� 5      $��Otkaži��6   
�������$��7,28,-7,-28q�6<   5      5      �� 5   
   ���	#FF70ABAF$��4q�6)   $ 8,8,8,8��6=   $��
10,0,10,85q�6T   ._�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ patientTable��5      "   VerticalScrollBarVisibility$
 Auto=�6o      AutoGenerateColumns$ False��6�      
IsReadOnly$
 True��6�      SelectionMode$ Single=�6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   $��6,6,6,6q�6�   	   GridLinesVisibility$	 
Horizontal=�6  ��6)   �� *
Patients+
 �� UpdateSourceTrigger$
 PropertyChanged=���6�   Z� ��60  Z�  � 	Resources 5      )  #System.Windows.Controls.DataGridRow �� 
TargetType��%E   '        �� 5      "  6   .�5      -   5        5       5!         Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$
 JMBG��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Id+  5$      $	 Ime��6%    62   �� *Ime+  5%      $ Prezime��6%    66   �� *	Prezime+5'      5(      �� 5+   
   ���#70ABAF���	#FF70ABAF$��1q�6>   $ 8��6R   $��81,286,162,18q�6c   ._�5,      � .+�5-      �� -   5         ��Name$ Schedule��5-      $�� ��6+   $��7,0,7,9q�66   ��6b   Z� ��5.      �� 5/      $  /Resources/acceptWhite.png��6%   51      �� 52      $��Prihvati��6   
�������$��7,28,-7,-28q�6>   53      54      56      57      