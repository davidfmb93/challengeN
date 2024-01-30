# ChallengeN

This project has been instrumental in showcasing the skills I've cultivated in the realm of development. While it may seem straightforward at first glance, it required a significant level of complexity to achieve a dynamic and effective environment

## Install

You should have installed

* Docker
* Docker Compose

You have differents alternatives to install the program:

1. You can execute the following lines using bash:
```sh
bash install.sh #first time
bash start.sh  #When you need running the program again
```

2. You can install program using The Makefile but you should install  [chocolatey](https://chocolatey.org/install). After that, run in command line: 

```sh
make INSTALL #first time
make RUN #When you need running the program again
```

3. You can lunch the program using docker-compose commands

When you run the previous commands you can go to the following link http://localhost:7201/swagger

## Tables
- 0 => Employee
- 1 => Permission
- 2 => Role

# Uses Cases

Create Rol

{
  "name": "Admin"
}

After create a role you can create Employee and Permissions with the rol id.
7a249fe1-593f-4051-8d09-fb47a12aeb53
## Connection DB

```
Server: localhost, 1433
Authentication type: SQL Login
user name: sa
database: master
Password: S3cur3P@ssW0rd!
```

<!-- ### Diagram DB

![Diagram DB](https://drive.google.com/uc?id=1KUHK2QgxnuFITLspn_DSWeqmW3KLAp_i) -->


<!-- ## UML

<img src="https://drive.google.com/uc?id=1QqzYbmU_YxQwiD2EerHkhinipTIX1rPo" data-canonical-src="https://drive.google.com/uc?id=1QqzYbmU_YxQwiD2EerHkhinipTIX1rPo" width="500" /> -->

## More Information

Contact: 
Email: davidfmb93@gmail.com
Github: https://github.com/davidfmb93