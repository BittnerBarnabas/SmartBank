   M S B A M L   `   `   `  ����K  GSmartBankDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SmartBankDesktop.ViewSmartBankDesktop.View  5   	   &     SmartBankDesktop.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SmartBankDesktop.View     5   	     � Title$  
MainWindow��5   	   $	��300��6   $	��681��6)   .��5	      � $��0,0,-292,-1q�6   .+�5
   
   �� $��Logged in as: ��6   $
��Left=�6)   $��	10,10,0,0q�6D   $	��Top=�6W   �� 5   
   -   5         ��Name$ UserNameLabel��5      $
��Left=�6L   $��	94,10,0,0q�5      $	��Top=�6#   $��26��6;   $��82��6G   ��5   '   �� *LoggedInUserName+5   G   �� 5   
   $��Bank Account Selector��6   $
��Left=�62   $	��166��6M   $��	10,46,0,0q�6Z   $	��Top=�5      $	��272��6+   .��5      � $
��Left=�6   $	��129��6.   $��5,10,0,0q�6;   $	��Top=�6M   $	��251��6e   .+�5      �� -   5         ��Name$ UserSelectorComboBox��5      $
��Left=�69   $��	99,10,0,0q�6T   $	��Top=�5      $	��142��63    �� DisplayMemberPath$
 Name��5   =   ��6   �� *	BankUsers+5      �� 5      -   5        $ AccountSelectorComboBox��5      $
��Left=�6<   $��	99,42,0,0q�6W   $	��Top=�6j   $	��142��6�   $ AccountNumber��5   M   ��6   �� *SelectedUser.BankAccounts+6M   �� 5      -   5        $��Select��5      $
��Left=�6*   $��
166,81,0,0q�6E   $	��Top=�6Y   $��75��5      6$   �� 5      $��	Username:��6   $
��Left=�6,   $��15,7,0,0q�6G   $	��Top=�6Y   �� 5      $��Account n.:��6   $
��Left=�6.   $��	15,41,0,0q�6I   $	��Top=�6\   5      5      �� 5   
   -   5         ��Name$ AccountDetailsGroupBox��5      $��Details��63   $
��Left=�6D   $	��166��6_   $��
292,46,0,0q�6l   $	��Top=�6�   $	��317��6�   .��5      � $
��Left=�6   $	��146��6.   $��
10,0,-2,-2q�6;   $	��Top=�6O   $	��297��6g   .+�5      �� -   5        $��Execute��5      $
��Left=�6+   $��213,116,0,0q�6F   $	��Top=�6[   $��74��6s   6~   �� 5      -   5         ��Name$ AmountTextBox��5      $
��Left=�61   $��24��6L   $��
148,10,0,0q�6X    �� TextWrapping$
 Wrap=�6l   $	��Top=�6�   $	��120��6�   �� 5       -   5        $ AccountNumberTextBox��5       $
��Left=�68   $��24��6S   $��
148,44,0,0q�6_   $
 Wrap=�6s   $	��Top=�6�   $	��120��6�   �� 5!      -	   5        $ AccountOwnerTextBox��5!      $
��Left=�67   $��24��6R   $��
148,80,0,0q�6^   $
 Wrap=�6r   $	��Top=�6�   $	��120��6�   �� 5"      $��Amount��6   $
��Left=�6)   $��	90,10,0,0q�6D   $	��Top=�6W   �� 5#      $��Acc. num��6   $
��Left=�6+   $��	90,44,0,0q�6F   $	��Top=�6Y   �� 5$      $��	Acc. own.��6   $
��Left=�6,   $��	90,80,0,0q�6G   $	��Top=�6Z   	� 5%      -
   5         	�Name$ MoneyOutRadioButton��5%       	� 	GroupName$ 	TransType��6;   $��	Money Out��6Q   $
��Left=�6e   $��16��6�   $��1,12,0,0q�6�   $	��Top=�6�   $��89��6�   	 d� 	IsChecked$
	 TrueY�6�   	� 5&      -   5        $ MoneyInRadioButton��5&      $ 	TransType��6:   $��Money In��6P   $
��Left=�6c   $��16��6~   $��1,33,0,0q�6�   $	��Top=�6�   $��89��6�   	� 5'      -   5        $ TransactionRadioButton��5'      $ 	TransType��6>   $��Transaction��6T   $
��Left=�6j   $��16��6�   $��1,54,0,0q�6�   $	��Top=�6�   $��89��6�   	� 5(      -   5        $ LockAccountRadioButton��5(      $ 	TransType��6>   $��Lock/Unlock��6T   $
��Left=�6j   $��16��6�   $��1,75,0,0q�6�   $	��Top=�6�   $��89��6�   �� 5)      -   5        $ LockedAccountLabel��5)      $��Locked account��64   $
��Left=�6M   $��28��6h   $��
16,108,0,0q�6t   $	��Top=�6�   
���  ��$
��Bold"�6�   5*      5+      �� 5,   
   $��Label��6   $
��Left=�6    $	��Top=�6;   �� 5-   
   $��Selected account:��6   $
��Left=�6,   $��
292,15,0,0q�6G   $	��Top=�6[   �� 5.   
   -   5        $  SelectedAccountNumberLabel��5.      $�� ��64   $
��Left=�6?   $��
400,15,0,0q�6Z   $	��Top=�6n   5/      50      