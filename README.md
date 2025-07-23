# Projet 5 : Créez votre première application avec ASP .NET Core (MVC)

Ce projet est la création d'un **site vitrine de voiture**, réalisée à l'aide de **diverses demandes précises d'un client fictif** et de **maquettes réalisées sur Figma**. 
Le but ici était de créer un **premier projet d'application web** avec des **directives d'un client**.

---
## Outils et technologies utilisés

- **Visual Studio 2022**
- **C# / ASP.NET Core**
- **SQL Server Management Studio**
- **Entity Framework**
- **Identity**
  
---
## Le back-end

- **Base de données** : SQL Server via EF Core (approche Code-First)
- **Gestion CRUD** (Ajout, modification, mise à jour et suppression) des voitures (réservé aux admins)
- **Upload de photo** lors de la création ou de la modification d’une voiture
- **Validation des fichiers** : extensions autorisées (.jpg, .jpeg, .png, .webp)
- **Sécurité et rôles** : Identity avec un rôle “Admin” pour restreindre l’accès à certaines pages
- **Protection CSRF** : [ValidateAntiForgeryToken] sur les actions sensibles
- **Autorisation** : [Authorize(Roles = "Admin")] sur les contrôleurs ou actions admin
- **Architecture SOLID** : séparation claire en Entités, Controllers, Interfaces, Repositories, Utils
- **Conventions C# respectées** (naming, PascalCase, commentaires,...)
  
---
## Le front-end

- **Découpage de la maquette** fournie sur **Figma**
- **Utilisation d'un design system** pour les patterns répétés (bouton CTA, titres, logo,...)
- **Utilisation de Bootstrap**

---
## Installation  

1. `git clone https://github.com/khiastos/Projet-5-OC.git`  
2. Ouvrir la solution dans Visual Studio  
3. Modifier la chaîne de connexion dans `appsettings.json` (pour afficher les voitures déjà existantes dans la BDD)
4. Lancer `Update-Database` dans la Console du Gestionnaire de Package  
5. Exécuter le projet

---
## Connexion en admin

- L'adresse mail du compte admin est dans `appsettings.json` : `admin@gmail.com`
- Le mot de passe est : Password123!

