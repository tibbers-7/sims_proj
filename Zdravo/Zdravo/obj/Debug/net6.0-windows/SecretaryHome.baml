   M S B A M L   `   `   `  ����A  =Zdravo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ZdravoZdravo  5   	       Zdravo.SecretaryHome   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Zdravo     5   	     � Title$  SecretaryHome��5   	   $	��750��6   $	��430��6,    � WindowStartupLocation$ CenterScreen=�68   .��5	      � .+�5
   
   �� $
��Left=�6   $	��100��6/   $��
61,114,0,0q�6<   
���   �$	��Top=�6_   $	��100��6w   �� 5   
   $
��Left=�6   $	��100��6/   $��266,114,0,0q�6<   
���   �$	��Top=�6`   $	��100��6x   �� 5   
   $
��Left=�6   $	��100��6/   $��
61,289,0,0q�6<   
���   �$	��Top=�6_   $	��100��6w   �� 5   
   $
��Left=�6   $	��100��6/   $��262,289,0,0q�6<   
���   �$	��Top=�6`   $	��100��6x   �� 5   
   $
��Left=�6   $	��100��6/   $��
61,483,0,0q�6<   
���   �$	��Top=�6_   $	��100��6w   �� 5   
   $
��Left=�6   $	��100��6/   $��262,483,0,0q�6<   
���   �$	��Top=�6`   $	��100��6x   �� 5   
   -   5        $�� ��5      $
��Left=�6   $��
61,114,0,0q�67   $	��Top=�6K   $	��100��6c   $	��100��6p   ��5      �� 5       �� ImageSource$ /Resources/doctor.png��6   5      �� 5   
   -   5         ��Name$ vacationLabel��5      $��Italic$�6+   $��20(�6>   $
��Left=�6L   $��
69,236,0,0q�6g   $
��Wrap=�6{   $��	Vacations��6�   $	��Top=�6�   �� 5   
   -   5        $ meetingsLabel��5      $��Italic$�6+   $��20(�6>   $
��Left=�6L   $��273,414,0,0q�6g   $
��Wrap=�6|   $��Meetings��6�   $	��Top=�6�   �� 5   
   -   5        $ 	appsLabel��5      $��Italic$�6'   $��20(�6:   $
��Left=�6H   $��
51,414,0,0q�6c   $
��Wrap=�6w   $��Appointments��6�   $	��Top=�6�   �� 5   
   -   5        $ patientsLabel��5      $��Italic$�6+   $��20(�6>   $
��Left=�6L   $��281,236,0,0q�6g   $
��Wrap=�6|   $��Patients��6�   $	��Top=�6�   �� 5   
   -   5        $ accountsLabel��5      $��Italic$�6+   $��20(�6>   $
��Left=�6L   $��
72,603,0,0q�6g   $
��Wrap=�6{   $��Report��6�   $	��Top=�6�   �� 5   
   -   5        $ ordersLabel��5      $��Italic$�6)   $��20(�6<   $
��Left=�6J   $��277,603,0,0q�6e   $
��Wrap=�6z   $��Orders��6�   $	��Top=�6�   �� 5   
   -   5        $�� ��5      $
��Left=�6   $��262,289,0,0q�67   $	��Top=�6L   $	��100��6d   $	��100��6q   ��5      �� 5      $ /Resources/meetings.png��6   5      �� 5    
   -	   5        $��patientsButton��5       $�� ��6'   $
��Left=�62   $��266,114,0,0q�6M   $	��Top=�6b   $	��100��6z   $	��100��6�   ��5!      �� 5"      $ /Resources/user.png��6   5$      �� 5%   
   -
   5        $�� ��5%      $
��Left=�6   $��
61,289,0,0q�67   $	��Top=�6K   $	��100��6c   $	��100��6p   ��5&      �� 5'      $ /Resources/calendar.png��6   5)      �� 5*   
   -   5        $�� ��5*      $
��Left=�6   $��
61,483,0,0q�67   $	��Top=�6K   $	��100��6c   $	��100��6p   ��5+      �� 5,      $ /Resources/report.png��6   5.      �� 5/   
   -   5        $�� ��5/      $
��Left=�6   $��262,483,0,0q�67   $	��Top=�6L   $	��100��6d   $	��100��6q   ��50      �� 51      $ /Resources/cart.png��6   53      �� 54   
   -   5        $�� ��54   (   $
��Left=�63   $��332,665,0,0q�6N   $	��Top=�6c   $��30��6{   $��30��6�   ��55      �� 56      $ /Resources/logout.png��6   58      �� 59   
   $
��Left=�6   $��30��6/   $��225,665,0,0q�6;   
���   �$	��Top=�6_   $	��102��6w   �� 5:   
   -   5         ��Name$ logOutButton��5:      
�������$��Log out��6:   $
��Left=�6L   $��225,666,0,0q�6g   $	��Top=�6|   $��29��6�   $	��102��6�   6�   �� 5;   
   $��Italic$�6   $��30(�6'   $
��Left=�65   $��	88,32,0,0q�6P   $
��Wrap=�6c   $��Klinika Zdravo��6w   $	��Top=�6�   �� 5<   
   $
��Left=�6   $��62��6+   $��	25,20,0,0q�67   $	��Top=�6J   $��52��6b    J� RenderTransformOrigin$ 0.676,0.514&�6m   $��/Resources/hospital.png��6�   �� 5=   
   -   5         ��Name$ comboBoxJezik��5=      $
��Left=�6*   $��
33,665,0,0q�6E   $	��Top=�6Y   $	��117��6q   $��30��6}   .@�5>      ��  �� 
IsSelected$
 True��6   .��5?      � .+�5@      �� $��30��6   $��30��6(   ��5A      �� 5B      .R�5C   "   �� $��25��6(   $��/Resources/english.png��64   6V   5D      5F      �� 5G      $��     English��6    $��Center=�64   5H      5I      �� 5J      .��5K      � .+�5L      �� $��30��6   $��30��6(   ��5M      �� 5N      .R�5O   "   �� $��25��6(   $��/Resources/serbia.png��64   6U   5P      5R      �� 5S      $��     Srpski��6    $��Center=�63   5T      5U      5W      5X      5Y      