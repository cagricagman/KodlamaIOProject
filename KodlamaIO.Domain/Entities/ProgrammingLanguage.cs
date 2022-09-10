﻿using Core.Persistence.Repositories;

namespace KodlamaIO.Domain.Entities;

public class ProgrammingLanguage : Entity
{
    public ProgrammingLanguage()
    {
        
    }
    public ProgrammingLanguage(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }

    public string Name { get; set; }
}