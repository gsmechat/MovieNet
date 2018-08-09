 Spécifications fonctionnelles :
Gestion des fiches de films :
La fiche d'un film est composée de son titre, de son genre (action, horreur, aventure, etc.), d'un résumé et de notes/commentaires donnés par les utilisateurs de l'application.

Votre logiciel doit fournir une fonction de recherche avancée permettant d'effectuer une recherche par critères sur les films: titre et genre au minimum. Pour cette partie, l'utilisation de Linq est obligatoire.

Gestion des utilisateurs :
Vous devez mettre en place un système d'authentification permettant aux utilisateurs de créer un compte, de pouvoir le modifier et s’authentifier sur le logiciel pour pouvoir utiliser ce dernier.

Consulter la fiche d'un film.
Ajouter, supprimer et modifier un film.
Noter et commenter celui-ci.
Effectuer des recherches.
Gestion des notes et des commentaires :
Les utilisateurs doivent pouvoir ajouter des commentaires sur la fiche d'un film et attribuer une note à celui-ci. L'ensemble des commentaires et la moyenne des notes d'un film doivent apparaitre sur la fiche du film en question.

 Spécifications techniques :
Architecture :
Votre logiciel devra être composé (au minimum) de deux projets:

Un projet WPF qui contiendra l'interface du logiciel.
Un projet qui servira à manipuler les données.
Interface graphique :
Votre projet WPF devra utiliser le pattern MVVM (le code-behind étant interdit).

Manipulation des données :
La manipulation des données doit se faire grâce à une base de données MSSQL, manipulée via Entity Framework.
Pour chaque type de données (utilisateurs, films) vous devez mettre en place un DAO. Ces DAO devront encapsuler tous les appels à Entity Framework et doivent être internes au projet de manipulation des données.
L'appel aux DAO doit se faire à travers une façade, cette façade doit être une classe publique singleton	et le point d'accès unique à vos données.
