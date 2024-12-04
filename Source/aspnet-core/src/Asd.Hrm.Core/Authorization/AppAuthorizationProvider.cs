using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Asd.Hrm.Authorization
{
    /// <summary>
    /// Application's authorization provider.
    /// Defines permissions for the application.
    /// See <see cref="AppPermissions"/> for all permission names.
    /// </summary>
    public class AppAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public AppAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public AppAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));
            pages.CreateChildPermission(AppPermissions.Pages_DemoUiComponents, L("DemoUiComponents"));

            var administration = pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var roles = administration.CreateChildPermission(AppPermissions.Pages_Administration_Roles, L("Roles"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Create, L("CreatingNewRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Edit, L("EditingRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Delete, L("DeletingRole"));

            var users = administration.CreateChildPermission(AppPermissions.Pages_Administration_Users, L("Users"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Create, L("CreatingNewUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Edit, L("EditingUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Delete, L("DeletingUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_ChangePermissions, L("ChangingPermissions"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Impersonation, L("LoginForUsers"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Unlock, L("Unlock"));

            var languages = administration.CreateChildPermission(AppPermissions.Pages_Administration_Languages, L("Languages"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Create, L("CreatingNewLanguage"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Edit, L("EditingLanguage"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Delete, L("DeletingLanguages"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_ChangeTexts, L("ChangingTexts"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_ChangeDefaultLanguage, L("ChangeDefaultLanguage"));
            
            administration.CreateChildPermission(AppPermissions.Pages_Administration_AuditLogs, L("AuditLogs"));

            var organizationUnits = administration.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits, L("OrganizationUnits"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree, L("ManagingOrganizationTree"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageMembers, L("ManagingMembers"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageRoles, L("ManagingRoles"));

            administration.CreateChildPermission(AppPermissions.Pages_Administration_UiCustomization, L("VisualSettings"));

            var webhooks = administration.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription, L("Webhooks"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription_Create, L("CreatingWebhooks"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription_Edit, L("EditingWebhooks"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription_ChangeActivity, L("ChangingWebhookActivity"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription_Detail, L("DetailingSubscription"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_Webhook_ListSendAttempts, L("ListingSendAttempts"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_Webhook_ResendWebhook, L("ResendingWebhook"));

            var dynamicProperties = administration.CreateChildPermission(AppPermissions.Pages_Administration_DynamicProperties, L("DynamicProperties"));
            dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicProperties_Create, L("CreatingDynamicProperties"));
            dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicProperties_Edit, L("EditingDynamicProperties"));
            dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicProperties_Delete, L("DeletingDynamicProperties"));

            var dynamicPropertyValues = dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicPropertyValue, L("DynamicPropertyValue"));
            dynamicPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicPropertyValue_Create, L("CreatingDynamicPropertyValue"));
            dynamicPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicPropertyValue_Edit, L("EditingDynamicPropertyValue"));
            dynamicPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicPropertyValue_Delete, L("DeletingDynamicPropertyValue"));

            var dynamicEntityProperties = dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityProperties, L("DynamicEntityProperties"));
            dynamicEntityProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityProperties_Create, L("CreatingDynamicEntityProperties"));
            dynamicEntityProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityProperties_Edit, L("EditingDynamicEntityProperties"));
            dynamicEntityProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityProperties_Delete, L("DeletingDynamicEntityProperties"));

            var dynamicEntityPropertyValues = dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityPropertyValue, L("EntityDynamicPropertyValue"));
            dynamicEntityPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityPropertyValue_Create, L("CreatingDynamicEntityPropertyValue"));
            dynamicEntityPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityPropertyValue_Edit, L("EditingDynamicEntityPropertyValue"));
            dynamicEntityPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityPropertyValue_Delete, L("DeletingDynamicEntityPropertyValue"));

            //TENANT-SPECIFIC PERMISSIONS

            pages.CreateChildPermission(AppPermissions.Pages_Tenant_Dashboard, L("Dashboard"), multiTenancySides: MultiTenancySides.Tenant);

            administration.CreateChildPermission(AppPermissions.Pages_Administration_Tenant_Settings, L("Settings"), multiTenancySides: MultiTenancySides.Tenant);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Tenant_SubscriptionManagement, L("Subscription"), multiTenancySides: MultiTenancySides.Tenant);

            //HOST-SPECIFIC PERMISSIONS

            var editions = pages.CreateChildPermission(AppPermissions.Pages_Editions, L("Editions"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Create, L("CreatingNewEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Edit, L("EditingEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Delete, L("DeletingEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_MoveTenantsToAnotherEdition, L("MoveTenantsToAnotherEdition"), multiTenancySides: MultiTenancySides.Host);

            var tenants = pages.CreateChildPermission(AppPermissions.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Create, L("CreatingNewTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Edit, L("EditingTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_ChangeFeatures, L("ChangingFeatures"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Delete, L("DeletingTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Impersonation, L("LoginForTenants"), multiTenancySides: MultiTenancySides.Host);

            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Settings, L("Settings"), multiTenancySides: MultiTenancySides.Host);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Maintenance, L("Maintenance"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_HangfireDashboard, L("HangfireDashboard"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Dashboard, L("Dashboard"), multiTenancySides: MultiTenancySides.Host);

            var resources = pages.CreateChildPermission(AppPermissions.Pages_Resources, L("Resources"), multiTenancySides: MultiTenancySides.Host);
            resources.CreateChildPermission(AppPermissions.Pages_Resources_Create, L("CreateNewResources"), multiTenancySides: MultiTenancySides.Host);
            resources.CreateChildPermission(AppPermissions.Pages_Resources_Edit, L("EditResources"), multiTenancySides: MultiTenancySides.Host);
            resources.CreateChildPermission(AppPermissions.Pages_Resources_Delete, L("DeleteResources"), multiTenancySides: MultiTenancySides.Host);
            
            var documentTemplates = pages.CreateChildPermission(AppPermissions.Pages_DocumentTemplates, L("DocumentTemplates"), multiTenancySides: MultiTenancySides.Host);
            documentTemplates.CreateChildPermission(AppPermissions.Pages_DocumentTemplates_Create, L("CreateNewDocumentTemplates"), multiTenancySides: MultiTenancySides.Host);
            documentTemplates.CreateChildPermission(AppPermissions.Pages_DocumentTemplates_Edit, L("EditDocumentTemplates"), multiTenancySides: MultiTenancySides.Host);
            documentTemplates.CreateChildPermission(AppPermissions.Pages_DocumentTemplates_Delete, L("DeleteDocumentTemplates"), multiTenancySides: MultiTenancySides.Host);

            // Contractors
            var contractors = pages.CreateChildPermission(AppPermissions.Pages_Contractors, L("Contractors"), multiTenancySides: MultiTenancySides.Host);
            contractors.CreateChildPermission(AppPermissions.Pages_Contractors_Create, L("CreateContractors"), multiTenancySides: MultiTenancySides.Host);
            contractors.CreateChildPermission(AppPermissions.Pages_Contractors_Edit, L("EditContractors"), multiTenancySides: MultiTenancySides.Host);
            contractors.CreateChildPermission(AppPermissions.Pages_Contractors_Delete, L("DeleteContractors"), multiTenancySides: MultiTenancySides.Host);

            var employees = pages.CreateChildPermission(AppPermissions.Pages_Employees, L("Employees"), multiTenancySides: MultiTenancySides.Host);
            employees.CreateChildPermission(AppPermissions.Pages_Employees_Create, L("CreateNewEmployees"), multiTenancySides: MultiTenancySides.Host);
            employees.CreateChildPermission(AppPermissions.Pages_Employees_Edit, L("EditEmployees"), multiTenancySides: MultiTenancySides.Host);
            employees.CreateChildPermission(AppPermissions.Pages_Employees_Delete, L("DeleteEmployees"), multiTenancySides: MultiTenancySides.Host);

            var projects = pages.CreateChildPermission(AppPermissions.Pages_Projects, L("Projects"), multiTenancySides: MultiTenancySides.Host);
            projects.CreateChildPermission(AppPermissions.Pages_Projects_Create, L("CreateNewProjects"), multiTenancySides: MultiTenancySides.Host);
            projects.CreateChildPermission(AppPermissions.Pages_Projects_Edit, L("EditProjects"), multiTenancySides: MultiTenancySides.Host);
            projects.CreateChildPermission(AppPermissions.Pages_Projects_Delete, L("DeleteProjects"), multiTenancySides: MultiTenancySides.Host);

            var tasks = pages.CreateChildPermission(AppPermissions.Pages_Tasks, L("Tasks"), multiTenancySides: MultiTenancySides.Host);
            tasks.CreateChildPermission(AppPermissions.Pages_Tasks_Create, L("CreateNewTasks"), multiTenancySides: MultiTenancySides.Host);
            tasks.CreateChildPermission(AppPermissions.Pages_Tasks_Edit, L("EditTasks"), multiTenancySides: MultiTenancySides.Host);
            tasks.CreateChildPermission(AppPermissions.Pages_Tasks_Delete, L("DeleteTasks"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, HrmConsts.LocalizationSourceName);
        }
    }
}
