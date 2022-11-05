using Microsoft.AspNetCore.Mvc;
using MicroserviceСompositeSC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MicroserviceCompositeSC.Models;

namespace MicroserviceСompositeSC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompositeSCController : ControllerBase
    {

        private readonly string _studentServiceAddress = "https://localhost:7139/api/students";
        private readonly string _courseServiceAddress = "https://localhost:7123/api/courses";

        [HttpGet]
        public string Start()
        {
            return "Composite is run!";
        }

        [HttpGet("courses/{discipleneName}")]
        public async Task<List<Course>> GetCoursesByDiscipleneAsync(string discipleneName)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (HttpClient client = new HttpClient(clientHandler))
            {
                HttpResponseMessage response = await client.GetAsync($"{_courseServiceAddress}");
                if (response.IsSuccessStatusCode)
                {
                    List<Course> courses = await JsonSerializer.DeserializeAsync<List<Course>>(await response.Content.ReadAsStreamAsync());
                    return courses.Where(course =>
                    course.Disciplenes.Split(',').Contains(discipleneName)).ToList();
                }
            }
            return null;
        }

        [HttpGet("students/{groupName}")]
        public async Task<List<Student>> GetStudentsByGroupAsync(string groupName)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (HttpClient client = new HttpClient(clientHandler))
            {
                HttpResponseMessage response = await client.GetAsync($"{_studentServiceAddress}");
                if (response.IsSuccessStatusCode)
                {
                    List<Student> students = await JsonSerializer.DeserializeAsync<List<Student>>(await response.Content.ReadAsStreamAsync());
                    return students.Where(student => student.GroupName == groupName).ToList();
                }
            }
            return null;
        }

        [HttpGet("rating/{groupName}")]
        public async Task<RatingOfGroup> GetAverageGroupRatingAsync(string groupName)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (HttpClient client = new HttpClient(clientHandler))
            {
                HttpResponseMessage response = await client.GetAsync($"{_studentServiceAddress}");
                if (response.IsSuccessStatusCode)
                {
                    List<Student> students = await JsonSerializer.DeserializeAsync<List<Student>>(await response.Content.ReadAsStreamAsync());
                    var collection = students.Where(st => st.GroupName == groupName).ToList();
                    long ratingSum = 0;
                    foreach (var i in collection) ratingSum += i.Rating;
                    return new RatingOfGroup()
                    {
                        GroupName = groupName,
                        AverageRating = (double)ratingSum / collection.Count
                    };

                }
            }
            return null;
        }

    }
}
