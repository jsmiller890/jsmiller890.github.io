   M S B A M L   `   `   `  ����M  IWPFRegisterStudent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFRegisterStudentWPFRegisterStudent  5   	   #    WPFRegisterStudent.AddStudent   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPFRegisterStudent     5   	     � Title$  
AddStudent��5   	   $	��450��6   $��742.143��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��747* �6   �� 5      $	��38* �6   �� 5      $	��10* �6   .+�5   
   �� -   5         ��Name$ firstnamelabel��5      $��
First Name��6(   $
��Left=�6=   $��	70,75,0,0q�6X   $	��Top=�6k   �� 5   
   -   5        $ lastnamelabel��5      $��	Last Name��6'   $
��Left=�6;   $��
70,121,0,0q�6V   $	��Top=�6j   �� 5   
   -   5        $ addresslabel��5      $��Address��6&   $
��Left=�68   $��
70,170,0,0q�6S   $	��Top=�6g   �� 5   
   -   5        $ 
emaillabel��5      $��E-mail��6$   $
��Left=�65   $��
70,222,0,0q�6P   $	��Top=�6d   �� 5   
   -   5        $ passwordlabel��5      $��Password��6'   $
��Left=�6:   $��
70,271,0,0q�6U   $	��Top=�6i   �� 5   
   -   5         ��Name$ firstnametxtbox��5      $
��Left=�6+   $��23��6F   $��
225,78,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��190��6�   6�   �� 5   
   -   5        $ lastnametxtbox��5      $
��Left=�6*   $��23��6E   $��225,124,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��190��6�   6�   �� 5   
   -   5        $ addresstxtbox��5      $
��Left=�6)   $��23��6D   $��225,173,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��190��6�   �� 5   
   -	   5        $ emailtxtbox��5      $
��Left=�6'   $��23��6B   $��225,225,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��190��6�    �� 
IsReadOnly . $��	@snhu.edu��6�   �� 5   
   -
   5        $ passwordtxtbox��5      $
��Left=�6*   $��23��6E   $��225,274,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��190��6�   �� 5   
   -   5         ��Name$ 
adduserbtn��5      $��Add Student��6%   $
��Left=�6;   $��
488,80,0,0q�6V   $	��Top=�6j   $	��147��6�   $	��222��6�   6�   �� 5   
   -   5         ��Name$ Admincheckbox��5      $��Administrator��6*   $
��Left=�6B   $��225,339,0,0q�6]   $	��Top=�6r   6�   �� 5   
   -   5        $ closebtn��5      $��Close Window��6#   $
��Left=�6:   $��488,339,0,0q�6U   $	��Top=�6j   $	��147��6�   $��36��6�   6�   5      5      