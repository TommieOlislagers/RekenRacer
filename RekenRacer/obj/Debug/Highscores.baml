   M S B A M L   `   `   `  ����E  ARekenRacer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:RekenRacer
RekenRacer  5   	       RekenRacer.Highscores   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:RekenRacer     5   	     � WindowStartupLocation$  CenterScreen=�5   =    � Title$ 
Highscores��5	   	   $	��450��6   $	��800��6*    � DataContext 5      ��  �� RelativeSource �� *Self+.��5
      �  � RowDefinitions 5   
   �� 5      6   �� 5      $��2* �6   6*   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      $��2* �6   6,   �� 5      6!   .+�5   
   �� $��	Helvetica)�6   $��28(�6'   $��0��65   $��1��6B   $��Center=�6R   $��Center=�6o   .��6�   RekenRacer highscore lijst6�   �� 5   
    �� Orientation$ Vertical=�6   $��1��6,   $��1��69   .+�5      �� -   5         ��Name$ ltbTransacties��5   /   
���������5      ��  �� Path$ HighscoreLijst�	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� View
 5      �� 5      .P�5      �� $��	Gebruiker��6)    �� DisplayMemberBinding 6<   �� *Gebruikersnaam+�� 5      $��	Highscore��6)    6<   �� *Score+�� 5      $��Datum��6)    68   �� *Datum+�� 5      $
��Tijd��6)    67   �� *Tijd+5      5!      �� 5#      -   5        $��Right=�5#      $	��107��61   .��6R   
Ga terug6\   5$      5&      5'      