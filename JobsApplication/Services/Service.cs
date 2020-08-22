using JobsApplication.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsApplication.Services
{
    public class Service
    {
        private readonly IMongoCollection<Job> jobs;

        public Service(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("JobsDB"));
            IMongoDatabase database = client.GetDatabase("JobsDB");
            jobs = database.GetCollection<Job>("Jobs");
        }

        public List<Job> Get()
        {
            return jobs.Find(job => true).ToList();
        }

        public Job Get(string id)
        {
            return jobs.Find(job => job.Id == id).FirstOrDefault();
        }

        public Job Create(Job job)
        {
            jobs.InsertOne(job);
            return job;
        }

        public void Update(string id, Job jobIn)
        {
            jobs.ReplaceOne(job => job.Id == id, jobIn);
        }

        public void Remove(Job jobIn)
        {
            jobs.DeleteOne(job => job.Id == jobIn.Id);
        }

        public void Remove(string id)
        {
            jobs.DeleteOne(job => job.Id == id);
        }
    }
}
