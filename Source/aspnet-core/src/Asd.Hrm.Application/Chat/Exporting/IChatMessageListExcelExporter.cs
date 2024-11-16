using System.Collections.Generic;
using Abp;
using Asd.Hrm.Chat.Dto;
using Asd.Hrm.Dto;

namespace Asd.Hrm.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
