   M S B A M L   `   `   `  ����M  IWPFRegisterStudent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFRegisterStudentWPFRegisterStudent  5   	   (    "WPFRegisterStudent.AdminMainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPFRegisterStudent     5   	   -   5          � Title$  Class Registration��5   	   $��395.902��6$   $	��525��65   .��5	      � .+�5
   
   �� -   5         ��Name$ comboBox��5
      $
��Left=�6%   $��	66,37,0,0q�6@   $	��Top=�6S   $	��164��6k    �� IsDropDownOpen . $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   6�   �� 5   
   -   5         ��Name$ button��5      $��Register for this course��6!   $
��Left=�6D   $��
283,37,0,0q�6_   $	��Top=�6s   $	��166��6�   6�   �� 5   
   -   5         ��Name$ listBox��5      $
��Left=�6#   $��69��6>   $��
66,276,0,0q�6J   $	��Top=�6^   $	��164��6v   6�   �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6#   $��23��6>   $��283,276,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $��0��6s   $	��Top=�6|   $��73��6�    �� 
IsReadOnly . 6�   �� 5   
   -   5        	 ��Name$	 label��5      $;��5Please select a course for which you want to register��6   $
��Left=�6_   $��66,7,0,0q�6z   $	��Top=�6�   $	��383��6�   �� 5   
   -   5        $	 label1��5      $'��!You are currently registered for:��6    $
��Left=�6L   $��
66,245,0,0q�6g   $	��Top=�6{   $	��176��6�   �� 5   
   -   5        $	 label2��5      $��Total Credit Hours��6    $
��Left=�6=   $��283,245,0,0q�6X   $	��Top=�6m   $	��106��6�   �� 5   
   -	   5        $	 label3��5      $�� ��6    $
��Left=�6+   $��
66,213,0,0q�6F   $	��Top=�6Z   $	��274��6r   ���	#FFEE0E0E6~   �� 5   
   -
   5        $	 courseIdlabel��5      $��
Course ID:��6'   $
��Left=�6<   $��	39,78,0,0q�6W   $	��Top=�6j   �� 5   
   -   5        
 ��Name$
 courseIdtxtblk��5      $
��Left=�6,   $��
120,83,0,0q�6G   $
��Wrap=�6[   $	��Top=�6o   $
��    ��6�   $��21��6�   $��78��6�   �� 5   
   -   5        $	 credithourlabel��5      $��Credit Hours:��6)   $
��Left=�6A   $��345,208,0,0q�6\   $	��Top=�6q   �� 5   
   -   5        $
 credithourstxtblk��5      $
��Left=�6/   $��446,213,0,0q�6J   $
��Wrap=�6_   $��0��6s   $	��Top=�6|   �� 5   
   -   5        $	 coursedesclabel��5      $��Course Description:��6)   $
��Left=�6G   $��
227,78,0,0q�6b   $	��Top=�6v   �� 5   
   -   5        $
 coursedesctxtblk��5      $
��Left=�6.   $��
39,109,0,0q�6I   $
��Wrap=�6]   $	��Top=�6q   $��       ��6�   $��66��6�   $	��427��6�   �� 5   
   -   5        $	 seatsleftlabel��5      $��Seats Remaining��6(   $
��Left=�6B   $��344,175,0,0q�6]   $	��Top=�6r   �� 5   
   -   5        $
 seatsremainingtxtblk��5      $
��Left=�62   $��446,180,0,0q�6M   $
��Wrap=�6b   $��0��6v   $	��Top=�6   �� 5   
   -   5        $ 
dropbutton��5      $��Drop this course��6%   $
��Left=�6@   $��258,325,0,0q�6[   $	��Top=�6p   $	��131��6�   6�   �� 5   
   -   5        $ closebtn��5      $��Close��6#   $
��Left=�63   $��418,325,0,0q�6N   $	��Top=�6c   $��75��6{   6�   5      5      