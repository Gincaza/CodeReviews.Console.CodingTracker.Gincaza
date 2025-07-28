﻿using BusinessLogicLayer;
using BusinessLogicLayer.Configuration;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
using PresentationLayer;

namespace CodeReviews.Console.CodingTracker;

public class Program
{
    public static void Main(string[] args)
    {
        // Initialize repository with connection string from configuration
        ICodingSessionRepository codingSessionRepository = 
            new CodingSessionRepository(ConfigurationManager.ConnectionString);
        
        // Create business logic layer with repository dependency
        BLLClass businessLogic = new BLLClass(codingSessionRepository);
        
        // Create and run the presentation layer controller
        CodingController codingController = new CodingController(businessLogic);
        codingController.Run();
    }
}