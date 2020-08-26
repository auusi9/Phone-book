# Phone Book #

Phone book is a small android app made with Unity, replicates a simple contacts app. You can add, edit and delate contacts.
You can edit the following details of a contact:

- Name
- LastName
- Phone
- Email
- TwitterHandle
- Description

The only mandatory fields are name, lastname and phone.

### Architecture ###

* Project has been made using the MVC pattern.
* The views communicate with the controllers via actions. Each controller + action represent a use case. 
* Controllers know about the models interface and about external services via adapters (in this case persistance service).
* Once the data of the models changes, it notificates to the view its changes. 

* This project uses Zenject to solve the dependency injection. Also uses Zenject's signal bus to fire actions and notifications. (https://github.com/svermeulen/Extenject)
* Contact list is a pool, it uses LoopScrollRect an open source pooling system for Unity's scroll rect (https://github.com/qiankanglai/LoopScrollRect) I extended the functionality of the plugin to make it work with Zenject's own pooling system.

### Setup ###

* Download and install unity, version: 2019.4.8f1 or later.
* Open the project with Unity and open the scene named "MainScene" inside the scenes folder.
* Press play to try it out

### Test it ###

* You can download the apk from here: (https://drive.google.com/file/d/1M9nJPlN5fOANUrHrvL4pil1-ZGjg01iq/view?usp=sharing)

### Made By ###

* Ausiàs Dalmau
* ausiasdalmauroig@gmail.com
* Sprites by Kenney (https://www.kenney.nl/assets/game-icons)