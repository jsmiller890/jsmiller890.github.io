   M S B A M L   `   `   `  ����M  IWPFRegisterStudent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFRegisterStudentWPFRegisterStudent  5   	   (    "WPFRegisterStudent.EditClassWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPFRegisterStudent     5   	     � Title$  EditClassWindow��5   	   $	��450��6!   $	��800��6.   .��5	      � .+�5
   
   �� -   5         ��Name$ courseidlabel��5
      $��	Course ID��6'   $
��Left=�6;   $��
273,31,0,0q�6V   $	��Top=�6j   $��33��6�   $��75��6�   �� 5   
   -   5        $ coursenamelabel��5      $��Course Name��6)   $
��Left=�6?   $��
273,74,0,0q�6Z   $	��Top=�6n   $��32��6�   $	��100��6�   �� 5   
   -   5        $ credithourslabel��5      $��Credit Hours��6*   $
��Left=�6A   $��
558,31,0,0q�6\   $	��Top=�6p   $��33��6�   $��94��6�   �� 5   
   -   5        $ classsizelabel��5      $��
Class Size��6(   $
��Left=�6=   $��274,124,0,0q�6X   $	��Top=�6m   $��33��6�   $��74��6�   �� 5   
   -   5        $ studentsregisteredlabel��5      $��Students Registered��61   $
��Left=�6O   $��487,124,0,0q�6j   $	��Top=�6   $��33��6�   $	��141��6�   �� 5   
   -   5         ��Name$ courseidtxtbox��5      $
��Left=�6*   $��29��6E   $��
378,31,0,0q�6Q    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��117��6�   �� 5   
   -   5        $ coursenametxtbox��5      $
��Left=�6,   $��29��6G   $��
378,74,0,0q�6S   $
 Wrap=�6g   $	��Top=�6{   $	��232��6�   �� 5   
   -   5        $ credithourstxtbox��5      $
��Left=�6-   $��29��6H   $��
666,31,0,0q�6T   $
 Wrap=�6h   $	��Top=�6|   $��71��6�   �� 5   
   -	   5        $ classsizetxtbox��5      $
��Left=�6+   $��29��6F   $��378,124,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $��83��6�   �� 5   
   -
   5        $ registeredtxtbox��5      $
��Left=�6,   $��29��6G   $��666,128,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $��89��6�    �� 
IsReadOnly . $��0��6�   �� 5   
   -   5         ��Name$ courseIdlistbox��5      $
��Left=�6+   $	��354��6F   $��	37,35,0,0q�6S   $	��Top=�6f   $	��226��6~   6�   �� 5   
   -   5         ��Name$ acceptchangebtn��5      $��Save Changes��6*   $
��Left=�6A   $��350,348,0,0q�6\   $	��Top=�6q   $	��141��6�   $��41��6�   6�   �� 5   
   -   5        $ 	cancelbtn��5      $��Cancel��6$   $
��Left=�65   $��596,348,0,0q�6P   $	��Top=�6e   $	��141��6}   $��41��6�   6�   �� 5   
   -   5        $ descriptiontxtbox��5      $
��Left=�6-   $��98��6H   $��274,220,0,0q�6T   $
 Wrap=�6i   $	��Top=�6}   $	��481��6�   �� 5   
   $��Description��6   $
��Left=�6&   $��274,176,0,0q�6A   $	��Top=�6V   $��74��6n   5      5      