using System.Collections.Generic;
using System.Linq;
using Projet.Models;
using Projet.Models.Entities;

namespace Projet.Data
{
    public class DBSeed


    {

        public static void Seed(ApplicationDbContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Entreprise entreprise = new Entreprise { Taxes = true, TPS = 0.05, TVQ = 0.0975, LivraisonGratuite = 1000, NomVendeur="ECommerce" };

            List<Category> Cats = new List<Category>();
            Category c1 = new Category { CategoryName = "Ordinateurs", Description = "Ordinateurs" };
            Category c2 = new Category { CategoryName = "Meubles", Description = " Imprimantes" };
            Category c3 = new Category { CategoryName = "Imprimantes", Description = " Tabletes" };
            Category c4 = new Category { CategoryName = "Bureaux", Description = "Les Tv" };
            Category c5 = new Category { CategoryName = "Tablettes", Description = " Nos Meubles" };
            Category c6 = new Category { CategoryName = "TVs", Description = "Nos bureaux" };

            c1.Produits = new List<Produit>(){



                        new Produit() {

                                                                    Name = "MAC BOOK",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST ONE",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc1.jpg",
                                                                    InStock = true,
                                                                    isPopular = true,
                                                                    Weight = 100, // grammes
                                                                    SalePrice = 200,
                                                                    Quantite  =  1000
                                                            } ,
                                                            new Produit() {

                                                                Name = "MAC BOOK2",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST Modele",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc2.jpg",
                                                                    InStock = true,
                                                                    isPopular = false,
                                                                    Weight = 500, // grammes
                                                                    SalePrice = 200,
                                                                    Quantite  =  100



                                                            },
                                                            new Produit() {

                                                                Name = "MAC BOOK 3",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST ONE",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc3.jpg",
                                                                    InStock = true,
                                                                    isPopular = true,
                                                                    Weight = 400, // grammes
                                                                    SalePrice = 2000,
                                                                    Quantite  =  200

                                                            },

                                                            new Produit() {

                                                                Name = "MAC BOOK 4",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST ONE",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc4.jpg",
                                                                    InStock = true,
                                                                    isPopular = true,
                                                                    Weight = 100, // grammes
                                                                    SalePrice = 200,
                                                                    Quantite  =  1000

                                                            },
                                                            new Produit() {

                                                                Name = "MAC BOOK 5",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST ONE",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc5.jpg",
                                                                    InStock = true,
                                                                    isPopular = true,
                                                                    Weight = 1000, // grammes
                                                                    SalePrice = 2100,
                                                                    Quantite  =  300

                                                            },
                                                            new Produit() {

                                                                Name = "MAC BOOK 6",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST ONE",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc6.jpg",
                                                                    InStock = true,
                                                                    isPopular = false,
                                                                    Weight = 200, // grammes
                                                                    SalePrice = 100,
                                                                    Quantite  =  5000

                                                            },
                                                            new Produit() {

                                                                Name = "MAC BOOK 7",
                                                                    AskedPrice = 1500,
                                                                    ShortDescription = "The BEST ONE",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc7.jpg",
                                                                    InStock = true,
                                                                    isPopular = true,
                                                                    Weight = 850, // grammes
                                                                    SalePrice = 1500,
                                                                    Quantite  =  700

                                                            },
                                                            new Produit() {

                                                                Name = "Lenovoo 1",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST Lenovoo",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc8.jpg",
                                                                    InStock = true,
                                                                    isPopular = true,
                                                                    Weight = 1200, // grammes
                                                                    SalePrice = 200,
                                                                    Quantite  =  100

                                                            },
                                                            new Produit() {

                                                                Name = "Lenovoo 2",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST Lenovoo2",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc9.jpg",
                                                                    InStock = true,
                                                                    isPopular = true,
                                                                    Weight = 1700, // grammes
                                                                    SalePrice = 1200,
                                                                    Quantite  =  1000

                                                            },
                                                            new Produit() {

                                                                Name = "Lenovoo 3",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST Lenovoo 3",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc10.jpg",
                                                                    InStock = true,
                                                                    isPopular = true,
                                                                    Weight = 1700, // grammes
                                                                    SalePrice = 2000,
                                                                    Quantite  =  1000

                                                            },

                                                            new Produit() {

                                                                Name = "Lenovoo 4",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST Lenovoo",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc11.jpg",
                                                                    InStock = true,
                                                                    isPopular = true,
                                                                    Weight = 1300, // grammes
                                                                    SalePrice = 2200,
                                                                    Quantite  =  1000

                                                            },

                                                            new Produit() {

                                                                Name = "Lenovoo 5",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST Lenovoo",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc12.jpg",
                                                                    InStock = false,
                                                                    isPopular = true,
                                                                    Weight = 1200, // grammes
                                                                    SalePrice = 200,
                                                                    Quantite  = 0

                                                            },
                                                            new Produit() {

                                                                Name = "Lenovoo 6",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST Lenovoo",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc13.jpg",
                                                                    InStock = false,
                                                                    isPopular = true,
                                                                    Weight = 50, // grammes
                                                                    SalePrice = 200,
                                                                    Quantite  =  100

                                                            },
                                                            new Produit() {

                                                                Name = "Lenovoo 7",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST Lenovoo 7",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc14.jpg",
                                                                    InStock = true,
                                                                    isPopular = false,
                                                                    Weight = 1200, // grammes
                                                                    SalePrice = 200,
                                                                    Quantite  =  100

                                                            },
                                                            new Produit() {

                                                                Name = "Lenovoo 8",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST Lenovoo 8",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc15.jpg",
                                                                    InStock = true,
                                                                    isPopular = true,
                                                                    Weight = 120, // grammes
                                                                    SalePrice = 200,
                                                                    Quantite  =  70

                                                            },
                                                            new Produit() {

                                                                Name = "Lenovoo 9",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST Lenovoo 9",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc16.jpg",
                                                                    InStock = true,
                                                                    isPopular = true,
                                                                    Weight = 1200, // grammes
                                                                    SalePrice = 200,
                                                                    Quantite  =  100

                                                            },
                                                            new Produit() {

                                                                Name = "Lenovoo 10",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST Lenovoo",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc17.jpg",
                                                                    InStock = true,
                                                                    isPopular = true,
                                                                    Weight = 1200, // grammes
                                                                    SalePrice = 200,
                                                                    Quantite  =  100

                                                            },

                                                             new Produit() {

                                                                Name = "Lenovoo 11",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST Lenovoo 11",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc18.jpg",
                                                                    InStock = true,
                                                                    isPopular = true,
                                                                    Weight = 1200, // grammes
                                                                    SalePrice = 200,
                                                                    Quantite  =  100

                                                            },

                                                            new Produit() {

                                                                Name = "PC MS 1",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST Microsoft PC 1",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc19.jpg",
                                                                    InStock = true,
                                                                    isPopular = true,
                                                                    Weight = 2200, // grammes
                                                                    SalePrice = 200,
                                                                    Quantite  =  500

                                                            },
                                                             new Produit() {

                                                                Name = "PC MS 2",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST Microsoft PC ",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc20.jpg",
                                                                    InStock = true,
                                                                    isPopular = true,
                                                                    Weight = 1200, // grammes
                                                                    SalePrice = 200,
                                                                    Quantite  =  500

                                                            },

                                                            new Produit() {

                                                                Name = "PC MS 3",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST Microsoft PC 3",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc21.jpg",
                                                                    InStock = true,
                                                                    isPopular = false,
                                                                    Weight = 1200, // grammes
                                                                    SalePrice = 200,
                                                                    Quantite  =  500

                                                            },

                                                            new Produit() {

                                                                Name = "PC MS 4",
                                                                    AskedPrice = 500,
                                                                    ShortDescription = "The BEST Microsoft PC 4",
                                                                    LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",
                                                                    Category = c1,
                                                                    ImageUrl = "~/images/pc22.jpg",
                                                                    InStock = true,
                                                                    isPopular = true,
                                                                    Weight = 1200, // grammes
                                                                    SalePrice = 200,
                                                                    Quantite  =  5000

                                                            },
                new Produit() {Name = "MAC BOOK-C1P01",AskedPrice = 501,ShortDescription = "The BEST ONE01",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c1,ImageUrl ="~/images/pc23.jpg",InStock = true,isPopular  = true,Weight  = 101,SalePrice = 201,Quantite  =  1001},
                new Produit() {Name = "MAC BOOK-C1P02",AskedPrice = 502,ShortDescription = "The BEST ONE02",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c1,ImageUrl = "~/images/pc24.jpg",InStock = false,isPopular = true,Weight  = 102,SalePrice = 202,Quantite  =  1002},
                new Produit() {Name = "MAC BOOK-C1P03",AskedPrice = 503,ShortDescription = "The BEST ONE03",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c1,ImageUrl = "~/images/pc25.jpg" ,InStock = true,isPopular  = false,Weight = 103,SalePrice = 203,Quantite  =  1003},
                new Produit() {Name = "MAC BOOK-C1P04",AskedPrice = 504,ShortDescription = "The BEST ONE04",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c1,ImageUrl = "~/images/pc26.jpg",InStock = true,isPopular  = true,Weight  = 104,SalePrice = 204,Quantite  =  1004},
                new Produit() {Name = "MAC BOOK-C1P05",AskedPrice = 505,ShortDescription = "The BEST ONE05",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c1,ImageUrl = "~/images/pc27.jpg",InStock = true,isPopular  = true,Weight  = 105,SalePrice = 205,Quantite  =  1005},
                new Produit() {Name = "MAC BOOK-C1P06",AskedPrice = 506,ShortDescription = "The BEST ONE06",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c1,ImageUrl = "~/images/pc28.jpg",InStock = false,isPopular = true,Weight  = 106,SalePrice = 206,Quantite  =  1006},
                new Produit() {Name = "MAC BOOK-C1P07",AskedPrice = 507,ShortDescription = "The BEST ONE07",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c1,ImageUrl = "~/images/pc29.jpg",InStock = true,isPopular  = true,Weight  = 107,SalePrice = 207,Quantite  =  1007},
                new Produit() {Name = "MAC BOOK-C1P08",AskedPrice = 508,ShortDescription = "The BEST ONE08",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c1,ImageUrl = "~/images/pc30.jpg",InStock = true,isPopular  = true,Weight  = 108,SalePrice = 208,Quantite  =  1008},
                new Produit() {Name = "MAC BOOK-C1P09",AskedPrice = 509,ShortDescription = "The BEST ONE09",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c1,ImageUrl = "~/images/pc31.jpg",InStock = true,isPopular  = true,Weight  = 109,SalePrice = 209,Quantite  =  1009},
                new Produit() {Name = "MAC BOOK-C1P10",AskedPrice = 510,ShortDescription = "The BEST ONE10",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c1,ImageUrl = "~/images/pc32.jpg",InStock = true,isPopular  = false,Weight = 110,SalePrice = 210,Quantite  =  1010}
            };

            c2.Produits = new List<Produit>(){

                new Produit() {Name = "Meubles BOOK-C2P01",AskedPrice = 501,ShortDescription = "The BEST ONE01",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c2,ImageUrl = "~/images/mb1.jpg",InStock = true,isPopular  = true,Weight  = 101,SalePrice = 201,Quantite  =  1001},
                new Produit() {Name = "Meubles BOOK-C2P02",AskedPrice = 502,ShortDescription = "The BEST ONE02",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c2,ImageUrl = "~/images/mb2.jpg",InStock = false,isPopular = true,Weight  = 102,SalePrice = 202,Quantite  =  1002},
                new Produit() {Name = "Meubles BOOK-C2P03",AskedPrice = 503,ShortDescription = "The BEST ONE03",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c2,ImageUrl = "~/images/mb3.jpg",InStock = true,isPopular  = false,Weight = 103,SalePrice = 203,Quantite  =  1003},
                new Produit() {Name = "Meubles BOOK-C2P04",AskedPrice = 504,ShortDescription = "The BEST ONE04",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c2,ImageUrl = "~/images/mb4.jpg",InStock = true,isPopular  = true,Weight  = 104,SalePrice = 204,Quantite  =  1004},
                new Produit() {Name = "Meubles BOOK-C2P05",AskedPrice = 505,ShortDescription = "The BEST ONE05",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c2,ImageUrl = "~/images/mb5.jpg",InStock = true,isPopular  = true,Weight  = 105,SalePrice = 205,Quantite  =  1005},
                new Produit() {Name = "Meubles BOOK-C2P06",AskedPrice = 506,ShortDescription = "The BEST ONE06",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c2,ImageUrl = "~/images/mb6.jpg",InStock = false,isPopular = true,Weight  = 106,SalePrice = 206,Quantite  =  1006},
                new Produit() {Name = "Meubles BOOK-C2P07",AskedPrice = 507,ShortDescription = "The BEST ONE07",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c2,ImageUrl = "~/images/mb7.jpg",InStock = true,isPopular  = true,Weight  = 107,SalePrice = 207,Quantite  =  1007},
                new Produit() {Name = "Meubles BOOK-C2P08",AskedPrice = 508,ShortDescription = "The BEST ONE08",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c2,ImageUrl = "~/images/mb8.jpg",InStock = true,isPopular  = true,Weight  = 108,SalePrice = 208,Quantite  =  1008},
                new Produit() {Name = "Meubles BOOK-C2P09",AskedPrice = 509,ShortDescription = "The BEST ONE09",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c2,ImageUrl = "~/images/mb9.jpg",InStock = true,isPopular  = true,Weight  = 109,SalePrice = 209,Quantite  =  1009},
                new Produit() {Name = "Meubles BOOK-C2P10",AskedPrice = 510,ShortDescription = "The BEST ONE10",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c2,ImageUrl = "~/images/mb10.jpg",InStock = true,isPopular  = false,Weight = 110,SalePrice = 210,Quantite  =  1010}
            };

            c3.Produits = new List<Produit>(){

                new Produit() {Name = "Imprimantes-C3P01",AskedPrice = 501,ShortDescription = "The BEST ONE01",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c3,ImageUrl = "~/images/printer11.jpg",InStock = true,isPopular  = true,Weight  = 101,SalePrice = 201,Quantite  =  1001},
                new Produit() {Name = "Imprimantes-C3P02",AskedPrice = 502,ShortDescription = "The BEST ONE02",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c3,ImageUrl = "~/images/printer22.jpg",InStock = false,isPopular = true,Weight  = 102,SalePrice = 202,Quantite  =  1002},
                new Produit() {Name = "Imprimantes-C3P03",AskedPrice = 503,ShortDescription = "The BEST ONE03",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c3,ImageUrl = "~/images/printer3.jpg",InStock = true,isPopular  = false,Weight = 103,SalePrice = 203,Quantite  =  1003},
                new Produit() {Name = "Imprimantes-C3P04",AskedPrice = 504,ShortDescription = "The BEST ONE04",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c3,ImageUrl = "~/images/printer4.jpg",InStock = true,isPopular  = true,Weight  = 104,SalePrice = 204,Quantite  =  1004},
                new Produit() {Name = "Imprimantes-C3P05",AskedPrice = 505,ShortDescription = "The BEST ONE05",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c3,ImageUrl = "~/images/printer5.jpg",InStock = true,isPopular  = true,Weight  = 105,SalePrice = 205,Quantite  =  1005},
                new Produit() {Name = "Imprimantes-C3P06",AskedPrice = 506,ShortDescription = "The BEST ONE06",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c3,ImageUrl = "~/images/printer6.jpg",InStock = false,isPopular = true,Weight  = 106,SalePrice = 206,Quantite  =  1006},
                new Produit() {Name = "Imprimantes-C3P07",AskedPrice = 507,ShortDescription = "The BEST ONE07",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c3,ImageUrl ="~/images/printer7.jpg",InStock = true,isPopular  = true,Weight  = 107,SalePrice = 207,Quantite  =  1007},
                new Produit() {Name = "Imprimantes-C3P08",AskedPrice = 508,ShortDescription = "The BEST ONE08",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c3,ImageUrl = "~/images/printer8.jpg",InStock = true,isPopular  = true,Weight  = 108,SalePrice = 208,Quantite  =  1008},
                new Produit() {Name = "Imprimantes-C3P09",AskedPrice = 509,ShortDescription = "The BEST ONE09",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c3,ImageUrl = "~/images/printer9.jpg",InStock = true,isPopular  = true,Weight  = 109,SalePrice = 209,Quantite  =  1009},
                new Produit() {Name = "Imprimantes-C3P10",AskedPrice = 510,ShortDescription = "The BEST ONE10",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c3,ImageUrl = "~/images/printer10.jpg",InStock = true,isPopular  = false,Weight = 110,SalePrice = 210,Quantite  =  1010}
            };

            c4.Produits = new List<Produit>(){

                new Produit() {Name = "Bureaux-C4P01",AskedPrice = 501,ShortDescription = "The BEST ONE01",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c4,ImageUrl = "~/images/desk1.jpg",InStock = true,isPopular  = true,Weight  = 101,SalePrice = 201,Quantite  =  1001},
                new Produit() {Name = "Bureaux-C4P02",AskedPrice = 502,ShortDescription = "The BEST ONE02",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c4,ImageUrl = "~/images/desk2.jpg",InStock = false,isPopular = true,Weight  = 102,SalePrice = 202,Quantite  =  1002},
                new Produit() {Name = "Bureaux-C4P03",AskedPrice = 503,ShortDescription = "The BEST ONE03",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c4,ImageUrl = "~/images/desk3.jpg",InStock = true,isPopular  = false,Weight = 103,SalePrice = 203,Quantite  =  1003},
                new Produit() {Name = "Bureaux-C4P04",AskedPrice = 504,ShortDescription = "The BEST ONE04",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c4,ImageUrl = "~/images/desk4.jpg",InStock = true,isPopular  = true,Weight  = 104,SalePrice = 204,Quantite  =  1004},
                new Produit() {Name = "Bureaux-C4P05",AskedPrice = 505,ShortDescription = "The BEST ONE05",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c4,ImageUrl = "~/images/desk5.jpg",InStock = true,isPopular  = true,Weight  = 105,SalePrice = 205,Quantite  =  1005},
                new Produit() {Name = "Bureaux-C4P06",AskedPrice = 506,ShortDescription = "The BEST ONE06",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c4,ImageUrl = "~/images/desk6.jpg",InStock = false,isPopular = true,Weight  = 106,SalePrice = 206,Quantite  =  1006},
                new Produit() {Name = "Bureaux-C4P07",AskedPrice = 507,ShortDescription = "The BEST ONE07",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c4,ImageUrl = "~/images/desk7.jpg",InStock = true,isPopular  = true,Weight  = 107,SalePrice = 207,Quantite  =  1007},
                new Produit() {Name = "Bureaux-C4P08",AskedPrice = 508,ShortDescription = "The BEST ONE08",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c4,ImageUrl = "~/images/desk8.jpg",InStock = true,isPopular  = true,Weight  = 108,SalePrice = 208,Quantite  =  1008},
                new Produit() {Name = "Bureaux-C4P09",AskedPrice = 509,ShortDescription = "The BEST ONE09",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c4,ImageUrl = "~/images/desk9.jpg",InStock = true,isPopular  = true,Weight  = 109,SalePrice = 209,Quantite  =  1009},
                new Produit() {Name = "Bureaux -C4P10",AskedPrice = 510,ShortDescription = "The BEST ONE10",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c4,ImageUrl = "~/images/desk10.jpg",InStock = true,isPopular  = false,Weight = 110,SalePrice = 210,Quantite  =  1010}
            };

            c5.Produits = new List<Produit>(){

                new Produit() {Name = "Tablette-C5P01",AskedPrice = 501,ShortDescription = "The BEST ONE01",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c5,ImageUrl = "~/images/tab11.jpg",InStock = true,isPopular  = true,Weight  = 101,SalePrice = 201,Quantite  =  1001},
                new Produit() {Name = "Tablette-C5P02",AskedPrice = 502,ShortDescription = "The BEST ONE02",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c5,ImageUrl = "~/images/tab22.jpg",InStock = false,isPopular = true,Weight  = 102,SalePrice = 202,Quantite  =  1002},
                new Produit() {Name = "Tablette-C5P03",AskedPrice = 503,ShortDescription = "The BEST ONE03",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c5,ImageUrl = "~/images/tab3.jpg",InStock = true,isPopular  = false,Weight = 103,SalePrice = 203,Quantite  =  1003},
                new Produit() {Name = "Tablette-C5P04",AskedPrice = 504,ShortDescription = "The BEST ONE04",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c5,ImageUrl = "~/images/tab4.jpg",InStock = true,isPopular  = true,Weight  = 104,SalePrice = 204,Quantite  =  1004},
                new Produit() {Name = "Tablette-C5P05",AskedPrice = 505,ShortDescription = "The BEST ONE05",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c5,ImageUrl = "~/images/tab5.jpg",InStock = true,isPopular  = true,Weight  = 105,SalePrice = 205,Quantite  =  1005},
                new Produit() {Name = "Tablette-C5P06",AskedPrice = 506,ShortDescription = "The BEST ONE06",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c5,ImageUrl = "~/images/tab6.jpg",InStock = false,isPopular = true,Weight  = 106,SalePrice = 206,Quantite  =  1006},
                new Produit() {Name = "Tablette-C5P07",AskedPrice = 507,ShortDescription = "The BEST ONE07",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c5,ImageUrl = "~/images/tab7.jpg",InStock = true,isPopular  = true,Weight  = 107,SalePrice = 207,Quantite  =  1007},
                new Produit() {Name = "Tablette-C5P08",AskedPrice = 508,ShortDescription = "The BEST ONE08",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c5,ImageUrl = "~/images/tab8.jpg",InStock = true,isPopular  = true,Weight  = 108,SalePrice = 208,Quantite  =  1008},
                new Produit() {Name = "Tablette-C5P09",AskedPrice = 509,ShortDescription = "The BEST ONE09",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c5,ImageUrl = "~/images/tab9.jpg",InStock = true,isPopular  = true,Weight  = 109,SalePrice = 209,Quantite  =  1009},
                new Produit() {Name = "Tablette-C5P10",AskedPrice = 510,ShortDescription = "The BEST ONE10",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c5,ImageUrl = "~/images/tab10.jpg",InStock = true,isPopular  = false,Weight = 110,SalePrice = 210,Quantite  =  1010}
            };

            c6.Produits = new List<Produit>(){

                new Produit() {Name = "TV -C6P01",AskedPrice = 501,ShortDescription = "The BEST ONE01",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c6,ImageUrl = "~/images/tv11.jpg",InStock = true,isPopular  = true,Weight  = 101,SalePrice = 201,Quantite  =  1001},
                new Produit() {Name = "TV-C6P02",AskedPrice = 502,ShortDescription = "The BEST ONE02",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c6,ImageUrl = "~/images/tv22.jpg",InStock = false,isPopular = true,Weight  = 102,SalePrice = 202,Quantite  =  1002},
                new Produit() {Name = "TV-C6P03",AskedPrice = 503,ShortDescription = "The BEST ONE03",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c6,ImageUrl = "~/images/tv33.jpg",InStock = true,isPopular  = false,Weight = 103,SalePrice = 203,Quantite  =  1003},
                new Produit() {Name = "TV-C6P04",AskedPrice = 504,ShortDescription = "The BEST ONE04",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c6,ImageUrl = "~/images/tv4.jpg",InStock = true,isPopular  = true,Weight  = 104,SalePrice = 204,Quantite  =  1004},
                new Produit() {Name = "TV-C6P05",AskedPrice = 505,ShortDescription = "The BEST ONE05",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c6,ImageUrl = "~/images/tv5.jpg",InStock = true,isPopular  = true,Weight  = 105,SalePrice = 205,Quantite  =  1005},
                new Produit() {Name = "TV-C6P06",AskedPrice = 506,ShortDescription = "The BEST ONE06",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c6,ImageUrl = "~/images/tv6.jpg",InStock = false,isPopular = true,Weight  = 106,SalePrice = 206,Quantite  =  1006},
                new Produit() {Name = "TV-C6P07",AskedPrice = 507,ShortDescription = "The BEST ONE07",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c6,ImageUrl = "~/images/tv7.jpg",InStock = true,isPopular  = true,Weight  = 107,SalePrice = 207,Quantite  =  1007},
                new Produit() {Name = "TV-C6P08",AskedPrice = 508,ShortDescription = "The BEST ONE08",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c6,ImageUrl = "~/images/tv8.jpg",InStock = true,isPopular  = true,Weight  = 108,SalePrice = 208,Quantite  =  1008},
                new Produit() {Name = "TV-C6P09",AskedPrice = 509,ShortDescription = "The BEST ONE09",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c6,ImageUrl = "~/images/tv9.jpg",InStock = true,isPopular  = true,Weight  = 109,SalePrice = 209,Quantite  =  1009},
                new Produit() {Name = "TV-C6P10",AskedPrice = 510,ShortDescription = "The BEST ONE10",LongDescription = "Offre réservée aux adhérents sur présentation de la carte Fnac en cours de validité pour l’achat de ce produit. Offre non cumulable avec toute autre remise ou promotion réservée ou non aux adhérents, valable dans l’ensemble des magasins Fnac participants et sur fnac.com (produits vendus et expédiés par fnac.com).",Category = c6,ImageUrl = "~/images/tv10.jpg",InStock = true,isPopular  = false,Weight = 110,SalePrice = 210,Quantite  =  1010}
            };


            Cats.Add(c1);
            Cats.Add(c2);
            Cats.Add(c3);
            Cats.Add(c4);
            Cats.Add(c5);
            Cats.Add(c6);

            //===============================================================================================================================

            if (!context.categories.Any())
            {
                context.Entreprise.Add(entreprise);
                context.categories.Add(c1);
                context.categories.Add(c2);
                context.categories.Add(c3);
                context.categories.Add(c4);
                context.categories.Add(c5);
                context.categories.Add(c6);
                context.SaveChanges();
            }



        }

    }
}










