using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsurancePolicyAPI.Data;
using InsurancePolicyAPI.Models;

namespace InsurancePolicyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InsurancePoliciesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public InsurancePoliciesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/InsurancePolicies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InsurancePolicy>>> GetPolicies()
    {
        return await _context.InsurancePolicies.ToListAsync();
    }

    // GET: api/InsurancePolicies/5
    [HttpGet("{id}")]
    public async Task<ActionResult<InsurancePolicy>> GetPolicy(int id)
    {
        var policy = await _context.InsurancePolicies.FindAsync(id);

        if (policy == null)
        {
            return NotFound();
        }

        return policy;
    }

    // POST: api/InsurancePolicies
    [HttpPost]
    public async Task<ActionResult<InsurancePolicy>> CreatePolicy(InsurancePolicy policy)
    {
        _context.InsurancePolicies.Add(policy);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPolicy), new { id = policy.Id }, policy);
    }

    // PUT: api/InsurancePolicies/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePolicy(int id, InsurancePolicy policy)
    {
        if (id != policy.Id)
        {
            return BadRequest();
        }

        _context.Entry(policy).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PolicyExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/InsurancePolicies/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePolicy(int id)
    {
        var policy = await _context.InsurancePolicies.FindAsync(id);
        if (policy == null)
        {
            return NotFound();
        }

        _context.InsurancePolicies.Remove(policy);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PolicyExists(int id)
    {
        return _context.InsurancePolicies.Any(e => e.Id == id);
    }
} 