   M S B A M L   `   `   `  ����M  IWPFRegisterStudent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFRegisterStudentWPFRegisterStudent  5   	   *    $WPFRegisterStudent.EditStudentWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPFRegisterStudent     5   	     � Title$  EditStudentWindow��5   	   $	��450��6#   $	��800��60   .��5	      � .+�5
   
   �� -   5         ��Name$ firstnamelabel��5
      $��
First Name��6(   $
��Left=�6=   $��
410,38,0,0q�6X   $	��Top=�6l   �� 5   
   -   5        $ lastnamelabel��5      $��	Last Name��6'   $
��Left=�6;   $��
410,84,0,0q�6V   $	��Top=�6j   �� 5   
   -   5        $ addresslabel��5      $��Address��6&   $
��Left=�68   $��410,133,0,0q�6S   $	��Top=�6h   �� 5   
   -   5        $ 
emaillabel��5      $��E-mail��6$   $
��Left=�65   $��410,185,0,0q�6P   $	��Top=�6e   �� 5   
   -   5        $ passwordlabel��5      $��Password��6'   $
��Left=�6:   $��410,234,0,0q�6U   $	��Top=�6j   �� 5   
   -   5         ��Name$ firstnametxtbox��5      $
��Left=�6+   $��23��6F   $��
565,41,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��190��6�    �� 
IsReadOnly . 6�   �� 5   
   -   5        $ lastnametxtbox��5      $
��Left=�6*   $��23��6E   $��
565,87,0,0q�6Q   $
 Wrap=�6e   $	��Top=�6y   $	��190��6�    . 6�   �� 5   
   -   5        $ addresstxtbox��5      $
��Left=�6)   $��23��6D   $��565,136,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��190��6�   �� 5   
   -	   5        $ emailtxtbox��5      $
��Left=�6'   $��23��6B   $��565,188,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��190��6�    . $��	@snhu.edu��6�   �� 5   
   -
   5        $ passwordtxtbox��5      $
��Left=�6*   $��23��6E   $��565,237,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��190��6�   �� 5   
   -   5         ��Name$ Admincheckbox��5      $��Administrator��6*   $
��Left=�6B   $��565,329,0,0q�6]   $	��Top=�6r   6�   �� 5   
   -   5         ��Name$ studentListbox��5      $
��Left=�6*   $	��344��6E   $��	29,41,0,0q�6R   $	��Top=�6e   $	��354��6}   $��2��6�   6�   �� 5   
   -   5         ��Name$ savebtn��5      $
��Save��6"   $
��Left=�61   $��443,380,0,0q�6L   $	��Top=�6a   $��75��6y   6�   �� 5   
   -   5        $ 	cancelbtn��5      $��Cancel��6$   $
��Left=�65   $��680,380,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5        $ 
adddropbtn��5      $��Add/Drop Classes��6%   $
��Left=�6@   $��548,380,0,0q�6[   $	��Top=�6p   $	��110��6�   6�   5      5      