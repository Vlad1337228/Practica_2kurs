   M S B A M L   `   `   `  ����D  @Practicka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Practicka	Practicka  5   	       Practicka.EnterWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Practicka     5   	     � Title$  EnterWindow��5   	   $	��501��6   $	��461��6*    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � $��	0,0,-5,-2q�6   ��5   
   �� 5       �� ImageSource$ backgroundEnter.jpg��6    j� Stretch$ UniformToFill=�6;   .+�5   
   �� -   5         ��Name$ 
labelEnter��5      $��Вход��6$   $��186,41,185,0q�63   $	��Top=�6I   $��Verdana)�6a   $��24(�6v   ���	#FF6E6E6E6�   �� 5   
   -   5        $ 
labelEmail��5      $��Эл.Почта��6$   $��82,143,242,0q�67   $	��Top=�6M   $��Verdana)�6e   $��20(�6z   ���	#FF6E6E6E6�   �� 5   
   -   5        $ labelPassword��5      $��Пароль��6'   $��82,218,236,0q�68   $	��Top=�6N   $��Verdana)�6f   $��20(�6{   ���	#FF6E6E6E6�   G� 5   
   -   5         G�Name$ boxPass��5      $
��Left=�6'   $��226,224,0,0q�6B   $	��Top=�6W   $	��147��6o   $��26��6{   ���	#FF6E6E6E$��0,0,0,1q�6�   ��5      �� 5       �� Color$ White��6"    �� Opacity$ 0Q�60   5      �� 5   
   -   5         ��Name$ buttonEnter��5      $��OK��6&   $��195,313,194,0q�63   $	��Top=�6J   
�������$��29��6u   ��5      �� 5      $ 	#FF707070��6"   $ 0Q�64   5      �� 5   
   -   5        $ buttonRegister��5      $��Нет аккаунта?��6)   $
��Left=�6A   $��195,344,0,0q�6\   $	��Top=�6q   $��69��6�   ���	#FFE6E0E0$��10(�6�   ��5      �� 5       $ 	#FF707070��6"   $ 0Q�64   ��5"      �� 5#      $ 	#FFFFF6F6��6"   $ 0Q�64   5%      �� 5&   
   -   5        	 ��Name$	 boxEmail��5&      $
��Left=�6$   $��26��6?   $��227,149,0,0q�6K   
 �� TextWrapping$

 Wrap=�6`   $	��Top=�6t   $	��147��6�   $��Verdana)�6�   $��20(�6�   ���	#FF6E6E6E���	#FF6E6E6E$��0,0,0,1q�6�   .��6  ��5'      �� 5(      $ White��6"   $ 0Q�60   .��5)   "   5+      5,      5-      