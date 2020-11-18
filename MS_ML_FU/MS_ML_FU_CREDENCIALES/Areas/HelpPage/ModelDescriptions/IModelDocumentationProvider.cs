using System;
using System.Reflection;

namespace MS_ML_FU_CREDENCIALES.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}