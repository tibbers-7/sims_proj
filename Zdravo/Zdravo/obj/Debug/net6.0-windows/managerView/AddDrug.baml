   M S B A M L   `   `   `  ����A  =Zdravo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Zdravo.managerViewZdravo.managerView  5   	        Zdravo.managerView.AddDrug   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Zdravo.managerView     5   	     � Title$  AddDrug��5   	   $	��450��6   $	��800��6&   .��5	      � .+�5
   
   �� $��Naziv:��6   $
��Left=�6!   $��
80,102,0,0q�6<   $	��Top=�6P   �� 5   
   $
��Left=�6   $��146,110,0,0q�6-    �� TextWrapping$
 Wrap=�6B   $	��Top=�6�   $	��120��6�   ��6V   ��  �� Path$ DrugName� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��Status:��6   $
��Left=�6"   $��
80,156,0,0q�6=   $	��Top=�6Q   �� 5   
   $
��Tip:��6   $
��Left=�6   $��80,0,0,0q�6:   $��Center=�6L   �� 5   
   $
��Left=�6   $��	146,0,0,0q�6-   $
 Wrap=�6@   $��Center=�6�   $	��120��6�   ��6T   �� $
 Type�$ PropertyChanged=�6�   �� 5   
   $��Opis:��6   $
��Left=�6    $��
80,247,0,0q�6;   $	��Top=�6O   $��88��6g   $��40��6r   �� 5   
   -   5        $��descriptionTb��5   �    �� TextAlignment$ Justify=�6X   $��146,267,482,39q�6p   " �� VerticalScrollBarVisibility$ Visible=�6�   $
 Wrap=�6�    �� 
IsReadOnly$ False��6�   ��6   �� $ Description�$ PropertyChanged=�6�   �� 5   
   $��	Sastojci:��6   $
��Left=�6$   $��
460,61,0,0q�6?   $	��Top=�6S   �� 5   
   -   5        $��comboStatus��5   g   $
��Left=�6   $��146,156,0,0q�6.   $	��Top=�6C   $	��120��6[   6g   �� 5   
   $��Zamena:��6   $
��Left=�6"   $��458,241,0,0q�6=   $	��Top=�6R   �� 5   
   -   5        $��comboDrugNames��5   g   $
��Left=�6   $��572,247,0,0q�6.   $	��Top=�6C   $	��120��6[   6g   �� 5   
   -   5        $��Dodaj��5      $
��Left=�6!   $��597,354,0,0q�6<   $	��Top=�6Q   6i   �� 5   
   $	��Id:��6   $
��Left=�6   $��	84,67,0,0q�69   $	��Top=�6L   �� 5   
   $
��Left=�6   $��
146,71,0,0q�6-   $
 Wrap=�6A   $	��Top=�6�   $	��120��6�   ��6U   �� $ Id�$ PropertyChanged=�6�   �� 5   
   -   5         ��Name$ ingridientsListView��5       �� SelectionMode$ Multiple=�6W   $��572,61,108,208q�6p   ��60   �� *AllIngridients+	 �� View	 5      �� 5      .P�5      �� 5      5      �� 5   
   -   5        $��Izmeni��5      $
��Left=�6"   $��678,354,0,0q�6=   $	��Top=�6R   6j   5!      5"      