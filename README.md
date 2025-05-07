
----  Projet Final – Application Agenda (C# WinForms)

Ce projet a été réalisé dans le cadre du cours de programmation en C# à l’hiver 2025. Il s’agit d’une application Windows Forms permettant de gérer un carnet de contacts et de rendez-vous, connecté à une base de données SQL Server.


----  Description

L’objectif était de créer une application fonctionnelle en C# avec WinForms, capable de :
- Gérer des **contacts** (ajout, recherche)
- Gérer des **rendez-vous** (ajout, affichage)
- Interagir avec une **base de données SQL Server** à l’aide de Dapper
- Offrir une interface utilisateur simple et intuitive

Ce projet m’a permis de découvrir l’environnement WinForms, de renforcer mes connaissances en structure de programme et d’apprendre à relier une base de données à une interface graphique.

--- Technologies utilisées

- C# avec Windows Forms (.NET)
- SQL Server (Base de données locale)
- DBeaver (gestion SQL sous Linux)
- Dapper (ORM léger pour C#)
- Visual Studio 2022 (dans VM)
- NuGet Packages : Dapper, SqlClient

---  Fonctionnalités principales

- Ajouter un **contact** dans la base de données
- Ajouter un **rendez-vous** avec heure et date
- Rechercher un contact selon différents critères (prénom, nom, ville...)
- Afficher les rendez-vous liés à une date sélectionnée

--- Structure du projet

1. `App.config` – Déclaration de la chaîne de connexion
2. `Helper.cs` – Classe utilitaire pour récupérer la `connectionString`
3. `DataAccess.cs` – Méthodes de lecture/écriture en base (Dapper)
4. `StructAgenda.cs` – Structures pour contacts et rendez-vous
5. `Form1.cs` – Interface graphique principale (UI)
6. Procédures SQL – Insertions et recherches côté base de données

--- Réalisé par

**Shirley Allaire**
Étudiante – Collège LaSalle – Programmeur-analyste
Session Hiver 2025

--- Ressource principale

- Tutoriel utilisé pour la connexion SQL en C# :
  [IAmTimCorey – Connect C# App to SQL](https://www.youtube.com/watch?v=Et2khGnrIqc)
