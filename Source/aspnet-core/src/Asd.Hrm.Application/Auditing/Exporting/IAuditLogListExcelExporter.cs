using System.Collections.Generic;
using Asd.Hrm.Auditing.Dto;
using Asd.Hrm.Dto;

namespace Asd.Hrm.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
