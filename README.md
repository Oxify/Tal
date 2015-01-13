# Tal Brody
.

How to install Git SCM:
1) Download and install:
a) http://git-scm.com/download/win
b) https://code.google.com/p/tortoisegit/wiki/Download
c) http://www.chiark.greenend.org.uk/~sgtatham/putty/download.html

2) Add Git path to system variable "path": bin and cmd.

3) cmd, go to /users/<user name>
ssh-keygen -t rsa -C "<your email>"
file path: .ssh/rsa_id
no passphrase

4) in github account - personal settings - ssh keys - add key
Paste text from .ssh/rsa_id.pub

5) make sure the home variable is set to right location (c:\users\<your user>)

6) test the connection: ssh -vT git@github.com
Help if it doesnt work: https://help.github.com/articles/generating-ssh-keys/

7) Get SSH repository URL from github website (like: git@github.com:Oxify/Tal.git)

8) Go to the relevant repository and change the URL in the origin to the SSH URL

9) run PuttyGen - Conversations - Import key - select rsa_id file
Click Save private key - rsa_id.ppk

10) add the following line to the config file in the origin section:
puttykeyfile = C:\\Users\\<your user name>\\.ssh\\id_rsa.ppk

(alternativly, go to the folder that holds the repository, right click, tortoisegit - settings -  git - Remote, click origin and add the putty key file)

And you are set!




