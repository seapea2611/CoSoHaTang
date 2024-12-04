using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.DynamicEntityProperties;
using Abp.EntityHistory;
using Abp.Localization;
using Abp.Notifications;
using Abp.Organizations;
using Abp.UI.Inputs;
using Abp.Webhooks;
using AutoMapper;
using IdentityServer4.Extensions;
using Asd.Hrm.Auditing.Dto;
using Asd.Hrm.Authorization.Accounts.Dto;
using Asd.Hrm.Authorization.Delegation;
using Asd.Hrm.Authorization.Permissions.Dto;
using Asd.Hrm.Authorization.Roles;
using Asd.Hrm.Authorization.Roles.Dto;
using Asd.Hrm.Authorization.Users;
using Asd.Hrm.Authorization.Users.Delegation.Dto;
using Asd.Hrm.Authorization.Users.Dto;
using Asd.Hrm.Authorization.Users.Importing.Dto;
using Asd.Hrm.Authorization.Users.Profile.Dto;
using Asd.Hrm.Chat;
using Asd.Hrm.Chat.Dto;
using Asd.Hrm.DynamicEntityProperties.Dto;
using Asd.Hrm.Editions;
using Asd.Hrm.Editions.Dto;
using Asd.Hrm.Friendships;
using Asd.Hrm.Friendships.Cache;
using Asd.Hrm.Friendships.Dto;
using Asd.Hrm.Localization.Dto;
using Asd.Hrm.MultiTenancy;
using Asd.Hrm.MultiTenancy.Dto;
using Asd.Hrm.MultiTenancy.HostDashboard.Dto;
using Asd.Hrm.MultiTenancy.Payments;
using Asd.Hrm.MultiTenancy.Payments.Dto;
using Asd.Hrm.Notifications.Dto;
using Asd.Hrm.Organizations.Dto;
using Asd.Hrm.Sessions.Dto;
using Asd.Hrm.WebHooks.Dto;
using Asd.Hrm.Resources.Dtos;
using Asd.Hrm.Contractors.Dtos;
using Asd.Hrm.Resource;
using Asd.Hrm.DocumentTemplates.Dtos;
using Asd.Hrm.DocumentTemplates;
using Asd.Hrm.Contractors;
using Asd.Hrm.Employees.Dtos;
using Asd.Hrm.Employee;
using Asd.Hrm.Projects.Dtos;

namespace Asd.Hrm
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //Inputs
            configuration.CreateMap<CheckboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<SingleLineStringInputType, FeatureInputTypeDto>();
            configuration.CreateMap<ComboboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<IInputType, FeatureInputTypeDto>()
                .Include<CheckboxInputType, FeatureInputTypeDto>()
                .Include<SingleLineStringInputType, FeatureInputTypeDto>()
                .Include<ComboboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<StaticLocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>();
            configuration.CreateMap<ILocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>()
                .Include<StaticLocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>();
            configuration.CreateMap<LocalizableComboboxItem, LocalizableComboboxItemDto>();
            configuration.CreateMap<ILocalizableComboboxItem, LocalizableComboboxItemDto>()
                .Include<LocalizableComboboxItem, LocalizableComboboxItemDto>();

            //Chat
            configuration.CreateMap<ChatMessage, ChatMessageDto>();
            configuration.CreateMap<ChatMessage, ChatMessageExportDto>();

            //Feature
            configuration.CreateMap<FlatFeatureSelectDto, Feature>().ReverseMap();
            configuration.CreateMap<Feature, FlatFeatureDto>();

            //Role
            configuration.CreateMap<RoleEditDto, Role>().ReverseMap();
            configuration.CreateMap<Role, RoleListDto>();
            configuration.CreateMap<UserRole, UserListRoleDto>();

            

            //Edition
            configuration.CreateMap<EditionEditDto, SubscribableEdition>().ReverseMap();
            configuration.CreateMap<EditionCreateDto, SubscribableEdition>();
            configuration.CreateMap<EditionSelectDto, SubscribableEdition>().ReverseMap();
            configuration.CreateMap<SubscribableEdition, EditionInfoDto>();

            configuration.CreateMap<Edition, EditionInfoDto>().Include<SubscribableEdition, EditionInfoDto>();

            configuration.CreateMap<SubscribableEdition, EditionListDto>();
            configuration.CreateMap<Edition, EditionEditDto>();
            configuration.CreateMap<Edition, SubscribableEdition>();
            configuration.CreateMap<Edition, EditionSelectDto>();


            //Payment
            configuration.CreateMap<SubscriptionPaymentDto, SubscriptionPayment>().ReverseMap();
            configuration.CreateMap<SubscriptionPaymentListDto, SubscriptionPayment>().ReverseMap();
            configuration.CreateMap<SubscriptionPayment, SubscriptionPaymentInfoDto>();

            //Permission
            configuration.CreateMap<Permission, FlatPermissionDto>();
            configuration.CreateMap<Permission, FlatPermissionWithLevelDto>();

            //Language
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageListDto>();
            configuration.CreateMap<NotificationDefinition, NotificationSubscriptionWithDisplayNameDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>()
                .ForMember(ldto => ldto.IsEnabled, options => options.MapFrom(l => !l.IsDisabled));

            //Tenant
            configuration.CreateMap<Tenant, RecentTenant>();
            configuration.CreateMap<Tenant, TenantLoginInfoDto>();
            configuration.CreateMap<Tenant, TenantListDto>();
            configuration.CreateMap<TenantEditDto, Tenant>().ReverseMap();
            configuration.CreateMap<CurrentTenantInfoDto, Tenant>().ReverseMap();

            //User
            configuration.CreateMap<User, UserEditDto>()
                .ForMember(dto => dto.Password, options => options.Ignore())
                .ReverseMap()
                .ForMember(user => user.Password, options => options.Ignore());
            configuration.CreateMap<User, UserLoginInfoDto>();
            configuration.CreateMap<User, UserListDto>();
            configuration.CreateMap<User, ChatUserDto>();
            configuration.CreateMap<User, OrganizationUnitUserListDto>();
            configuration.CreateMap<Role, OrganizationUnitRoleListDto>();
            configuration.CreateMap<CurrentUserProfileEditDto, User>().ReverseMap();
            configuration.CreateMap<UserLoginAttemptDto, UserLoginAttempt>().ReverseMap();
            configuration.CreateMap<ImportUserDto, User>();

            //AuditLog
            configuration.CreateMap<AuditLog, AuditLogListDto>();
            configuration.CreateMap<EntityChange, EntityChangeListDto>();
            configuration.CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();

            //Friendship
            configuration.CreateMap<Friendship, FriendDto>();
            configuration.CreateMap<FriendCacheItem, FriendDto>();

            //OrganizationUnit
            configuration.CreateMap<OrganizationUnit, OrganizationUnitDto>();

            //Webhooks
            configuration.CreateMap<WebhookSubscription, GetAllSubscriptionsOutput>();
            configuration.CreateMap<WebhookSendAttempt, GetAllSendAttemptsOutput>()
                .ForMember(webhookSendAttemptListDto => webhookSendAttemptListDto.WebhookName,
                    options => options.MapFrom(l => l.WebhookEvent.WebhookName))
                .ForMember(webhookSendAttemptListDto => webhookSendAttemptListDto.Data,
                    options => options.MapFrom(l => l.WebhookEvent.Data));

            configuration.CreateMap<WebhookSendAttempt, GetAllSendAttemptsOfWebhookEventOutput>();

            configuration.CreateMap<DynamicProperty, DynamicPropertyDto>().ReverseMap();
            configuration.CreateMap<DynamicPropertyValue, DynamicPropertyValueDto>().ReverseMap();
            configuration.CreateMap<DynamicEntityProperty, DynamicEntityPropertyDto>()
                .ForMember(dto => dto.DynamicPropertyName,
                    options => options.MapFrom(entity => entity.DynamicProperty.DisplayName.IsNullOrEmpty() ? entity.DynamicProperty.PropertyName : entity.DynamicProperty.DisplayName));
            configuration.CreateMap<DynamicEntityPropertyDto, DynamicEntityProperty>();

            configuration.CreateMap<DynamicEntityPropertyValue, DynamicEntityPropertyValueDto>().ReverseMap();
            
            //User Delegations
            configuration.CreateMap<CreateUserDelegationDto, UserDelegation>();

            /* ADD YOUR OWN CUSTOM AUTOMAPPER MAPPINGS HERE */
            configuration.CreateMap<CreateOrEditResourcesDto, Asd.Hrm.Resource.Resources>();
            configuration.CreateMap<CreateOrEditResourcesDto, Asd.Hrm.Resource.Resources>().ReverseMap();
            configuration.CreateMap<Asd.Hrm.Resource.Resources, ResourcesDto>();
            configuration.CreateMap<Asd.Hrm.Resource.Resources, ResourcesDto>().ReverseMap();

            configuration.CreateMap<CreateOrEditDocumentTemplatesDto, Asd.Hrm.DocumentTemplates.DocumentTemplates>();
            configuration.CreateMap<CreateOrEditDocumentTemplatesDto, Asd.Hrm.DocumentTemplates.DocumentTemplates>().ReverseMap();
            configuration.CreateMap<Asd.Hrm.DocumentTemplates.DocumentTemplates, DocumentTemplatesDto>();
            configuration.CreateMap<Asd.Hrm.DocumentTemplates.DocumentTemplates, DocumentTemplatesDto>().ReverseMap();

            configuration.CreateMap<CreateOrEditContractorsDto, Asd.Hrm.Contractor.Contractors>();
            configuration.CreateMap<CreateOrEditContractorsDto, Asd.Hrm.Contractor.Contractors>().ReverseMap();
            configuration.CreateMap<Asd.Hrm.Contractor.Contractors, ContractorsDto>();
            configuration.CreateMap<Asd.Hrm.Contractor.Contractors, ContractorsDto>().ReverseMap();

            configuration.CreateMap<CreateOrEditEmployeesDto, Asd.Hrm.Employee.Employees>();
            configuration.CreateMap<CreateOrEditEmployeesDto, Asd.Hrm.Employee.Employees>().ReverseMap();
            configuration.CreateMap<Asd.Hrm.Employee.Employees, EmployeesDto>();
            configuration.CreateMap<Asd.Hrm.Employee.Employees, EmployeesDto>().ReverseMap();

            configuration.CreateMap<CreateOrEditProjectsDto, Asd.Hrm.Project.Projects>();
            configuration.CreateMap<CreateOrEditProjectsDto, Asd.Hrm.Project.Projects>().ReverseMap();
            configuration.CreateMap<Asd.Hrm.Project.Projects, ProjectsDto>();
            configuration.CreateMap<Asd.Hrm.Project.Projects, ProjectsDto>().ReverseMap();
        }
    }
}
