using MediatR;
using SuiviCompresseur.GestionFournisseur.Application.Interfaces;
using SuiviCompresseur.GestionFournisseur.Application.Services;
using SuiviCompresseur.GestionFournisseur.Data.Context;
using SuiviCompresseur.GestionFournisseur.Data.Repository;
using SuiviCompresseur.GestionFournisseur.Domain.CommandHandlers;
using SuiviCompresseur.GestionFournisseur.Domain.Commands;
using SuiviCompresseur.GestionFournisseur.Domain.Interfaces;
//using SuiviCompresseur.Domain.Core.Bus;
//using SuiviCompresseur.Infra.Bus;
//using SuiviCompresseur.GestionCompresseur.Application.Interfaces;
//using SuiviCompresseur.GestionCompresseur.Application.Services;
using SuiviCompresseur.GestionCompresseur.Data.Context;
using SuiviCompresseur.GestionCompresseur.Data.Repository;
using SuiviCompresseur.GestionCompresseur.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using SuiviCompresseur.Gestion.Responsable.Domain.Interfaces;
using SuiviCompresseur.Gestion.Responsable.Data.Repository;
using SuiviCompresseur.Gestion.Responsable.Data.Context;
using SuiviCompresseur.Gestion.Responsable.Aplication.Interfaces;
using SuiviCompresseur.Gestion.Responsable.Aplication.Services;
using SuiviCompresseur.Gestion.Responsable.Domain.Commands;
using SuiviCompresseur.Gestion.Responsable.Domain.CommandHandlers;
//using SuiviCompresseur.GestionCompresseur.Domain.Events;
//using SuiviCompresseur.GestionCompresseur.Domain.EventHandlers;
using SuiviCompresseur.GestionCompresseur.Domain.CommandHandlers;
using SuiviCompresseur.GestionCompresseur.Domain.Models;
using SuiviCompresseur.GestionCompresseur.Domain.Queries;
using SuiviCompresseur.GestionFournisseur.Domain.CommandHandlers.Handlers;
using SuiviCompresseur.GestionFournisseur.Domain.Commands.FournisseurCommands;
using SuiviCompresseur.GestionFournisseur.Domain.Models;
using SuiviCompresseur.GestionFournisseur.Domain.Queries;
using SuiviCompresseur.Gestion.Responsable.Domain.Queries;
using SuiviCompresseur.Gestion.Responsable.Domain.Models;
using SuiviCompresseur.Notification.Domain.Queries;
using SuiviCompresseur.Notification.Domain.Handlers;
using SuiviCompresseur.Notification.Domain.Commands;
using SuiviCompresseur.Notification.Domain.Interfaces;
using SuiviCompresseur.Notification.Domain.Models;
using SuiviCompresseur.Notification.Data.Repositories;
using SuiviCompresseur.Notification.Data.Context;
using SuiviCompresseur.GestionCompresseur.Domain.Commands;

namespace SuiviCompresseur.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            ////Domain Bus
            //services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            //{
            //    var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
            //    return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            //});

            ////Subscriptions
            //services.AddTransient<CreationEventHandler>();
            //services.AddTransient<FilialeEventHandler>();


            ////Domain Events
            //services.AddTransient<IEventHandler<CreationDoneEvent>, CreationEventHandler>();
            //services.AddTransient<IEventHandler<SendListeCreateEvent>, FilialeEventHandler>();

            ////Domain Commands
            //services.AddTransient<IRequestHandler<CreateFournisseurCommand, bool>, FournisseurCommandHandler>();
            //services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();


            //services.AddTransient<ICompresseurService, CompresseurService>();
            //services.AddTransient<ICompresseurRepository, CompresseurRepository>();

            //services.AddTransient<IFilialeDupService, FilialeDupService>();
            //services.AddTransient<IFilialeDupRepository, FilialeDupRepository>();


            //     Fournisseur
            services.AddTransient<FournisseurDbContext>();
            services.AddTransient<IFournisseurRepository, FournisseurRepository>();
            services.AddTransient<IFournisseurService, FournisseurService>();
            services.AddTransient<IRequestHandler<GetFournisseurQuery, Fournisseur>, GetFournisseurHandler>();
            services.AddTransient<IRequestHandler<PutFournisseurCommand, string>, PutFournisseurHandler>();
            services.AddTransient<IRequestHandler<RemoveFournisseurCommand, string>, RemoveFournisseurHandler>();
            services.AddTransient<IRequestHandler<GetFournisseursQuery, IEnumerable<Fournisseur>>, GetFournisseursHandlers>();
            services.AddTransient<IRequestHandler<AddFournisseurCommand, string>, AddFournisseurHandler>();

            //     Compresseur Fililale
            services.AddTransient<CompresseurDbContext>();
            services.AddTransient<IGenericRepository<CompresseurFiliale>, GenericRepository<CompresseurFiliale>>();
            services.AddTransient<IRequestHandler<CreateGenericCommand<CompresseurFiliale>, string>, CreateGenericHandler<CompresseurFiliale>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<CompresseurFiliale>, CompresseurFiliale>, GetGenericHandler<CompresseurFiliale>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<CompresseurFiliale>, string>, PutGenericHandler<CompresseurFiliale>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<CompresseurFiliale>, string>, RemoveGenericHandler<CompresseurFiliale>>();
            services.AddTransient<IRequestHandler<GetAllGenericQuery<CompresseurFiliale>, IEnumerable<CompresseurFiliale>>, GetAllGenericHandler<CompresseurFiliale>>();

            //     fiche compresseur
            services.AddTransient<IGenericRepository<FicheCompresseur>, GenericRepository<FicheCompresseur>>();
            services.AddTransient<IRequestHandler<CreateGenericCommand<FicheCompresseur>, string>, CreateGenericHandler<FicheCompresseur>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<FicheCompresseur>, FicheCompresseur>, GetGenericHandler<FicheCompresseur>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<FicheCompresseur>, string>, PutGenericHandler<FicheCompresseur>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<FicheCompresseur>, string>, RemoveGenericHandler<FicheCompresseur>>();
            services.AddTransient<IRequestHandler<GetAllGenericQuery<FicheCompresseur>, IEnumerable<FicheCompresseur>>, GetAllGenericHandler<FicheCompresseur>>();

            //     Consommable
            services.AddTransient<IGenericRepository<Consommable>, GenericRepository<Consommable>>();
            services.AddTransient<IRequestHandler<CreateGenericCommand<Consommable>, string>, CreateGenericHandler<Consommable>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<Consommable>, Consommable>, GetGenericHandler<Consommable>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Consommable>, string>, PutGenericHandler<Consommable>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Consommable>, string>, RemoveGenericHandler<Consommable>>();
            services.AddTransient<IRequestHandler<GetAllGenericQuery<Consommable>, IEnumerable<Consommable>>, GetAllGenericHandler<Consommable>>();



            //      GRH
            services.AddTransient<IGenericRepository<GRH>, GenericRepository<GRH>>();
            services.AddTransient<IRequestHandler<CreateGenericCommand<GRH>, string>, CreateGenericHandler<GRH>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<GRH>, GRH>, GetGenericHandler<GRH>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<GRH>, string>, PutGenericHandler<GRH>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<GRH>, string>, RemoveGenericHandler<GRH>>();
            services.AddTransient<IRequestHandler<GetAllGenericQuery<GRH>, IEnumerable<GRH>>, GetAllGenericHandler<GRH>>();

            //Fiche_Suivi
            services.AddTransient<ValidationContraint>();
            services.AddTransient<IGenericRepository<Fiche_Suivi>, GenericRepository<Fiche_Suivi>>();
            services.AddTransient<IRequestHandler<CreateGenericCommand<Fiche_Suivi>, string>, CreateGenericHandler<Fiche_Suivi>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<Fiche_Suivi>, Fiche_Suivi>, GetGenericHandler<Fiche_Suivi>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Fiche_Suivi>, string>, PutGenericHandler<Fiche_Suivi>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Fiche_Suivi>, string>, RemoveGenericHandler<Fiche_Suivi>>();
            services.AddTransient<IRequestHandler<GetAllGenericQuery<Fiche_Suivi>, IEnumerable<Fiche_Suivi>>, GetAllGenericHandler<Fiche_Suivi>>();


            //Users
            services.AddTransient<Gestion_Responsable_DBContext>();
            services.AddTransient<IGenericRepositoryResponsable<Users>, GenericRepositoryResponsable<Users>>();
            services.AddTransient<IRequestHandler<CreateGenericCommandGR<Users>, string>, CreateGenericHandlerGR<Users>>();
            services.AddTransient<IRequestHandler<GetGenericQueryGR<Users>, Users>, GetGenericHandlerGR<Users>>();
            services.AddTransient<IRequestHandler<PutGenericCommandGR<Users>, string>, PutGenericHandlerGR<Users>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommandGR<Users>, string>, RemoveGenericHandlerGR<Users>>();
            services.AddTransient<IRequestHandler<GetAllGenericQueryGR<Users>, IEnumerable<Users>>, GetAllGenericHandlerGR<Users>>();

            //   Filiale
            services.AddTransient<IGenericRepositoryResponsable<Filiale>, GenericRepositoryResponsable<Filiale>>();
            services.AddTransient<IFilialeService, FilialeService>();
            services.AddTransient<IRequestHandler<CreateGenericCommandGR<Filiale>, string>, CreateGenericHandlerGR<Filiale>>();
            services.AddTransient<IRequestHandler<GetGenericQueryGR<Filiale>, Filiale>, GetGenericHandlerGR<Filiale>>();
            services.AddTransient<IRequestHandler<PutGenericCommandGR<Filiale>, string>, PutGenericHandlerGR<Filiale>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommandGR<Filiale>, string>, RemoveGenericHandlerGR<Filiale>>();
            services.AddTransient<IRequestHandler<GetAllGenericQueryGR<Filiale>, IEnumerable<Filiale>>, GetAllGenericHandlerGR<Filiale>>();

            // Notification
            services.AddTransient<IRequestHandler<GetNotificationsQuery, IEnumerable<EmailFrom>>, GetNotificationHandler>();
            services.AddTransient<IRequestHandler<SendEmailCommand, string>, SendEmailHandler>();
            services.AddTransient<IRequestHandler<NotificationSeenCommand, string>, NotificationSeenHandler>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<Notification_context>();





            
            
            


            
            




        }
    }
}
