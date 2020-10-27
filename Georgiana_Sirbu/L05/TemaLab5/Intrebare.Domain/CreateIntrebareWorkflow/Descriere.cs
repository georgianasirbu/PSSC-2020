using CSharp.Choices;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intrebare.Domain.CreateIntrebareWorkflow
{
    [AsChoice]
    public static partial class Question_Description
    {
        public interface IDescription { }
        public class Nepublicata : IDescription
        {
            public string Descriere { get; private set; }
            public List<string> Tag { get; private set; }
           
            private UnpublishedQuestion(string descriere,List<string>tag)
            {
                Descriere = descriere;
                Tag = tag;
            }

            public static Result<Nepublicata> Create(string descriere,List<string>tag)
            {
                if (IsQuestionValid(descriere))
                {
                    if(IsTagValid(tag))
                    {
                        return new Nepublicata(descriere, tag);
                    }
                    else
                    {
                        return new Result<Nepublicata>(new ExceptionTag(tag));
                    }
                }
                else
                {
                    return new Result<Nepublicata>(new ExceptieTitlu(descriere));
                }
            }

            private static bool IsQuestionValid(string descriere)
            {
                if (descriere.Length<1000)
                {
                    return true;
                }
                return false;
            }
            private static bool IsTagValid(List<string> tag)
            {
                if (tag.Count>=1 && tag.Count<=3)
                {
                    return true;
                }
                return false;
            }
        }
        public class Publicata : IDescription
        {
            public string Descriere { get; private set; }
            public List<string> Tag { get; private set; }

            internal PublishedQuestion(string descriere, List<string> tag)
            {
                    Descriere = descriere;
                    Tag = tag;
            }
        }
    }
}
